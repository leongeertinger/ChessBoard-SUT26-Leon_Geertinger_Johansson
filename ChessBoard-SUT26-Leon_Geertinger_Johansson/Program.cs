namespace ChessBoard_SUT26_Leon_Geertinger_Johansson
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Board board = new Board();

            int size = 0;
            while (size == 0)
            {
                try
                {
                    Console.WriteLine("Hur stort bräde vill du ha?");
                    size = byte.Parse(Console.ReadLine());
                    if (size < 1 || size > 100)
                    {
                        throw new Exception();
                    }

                }
                catch
                {
                    Console.WriteLine("Var god skriv ett tal mellan 1 - 100.");
                }
            }

            char[] boardObject = board.getBoard(size);

            board.printBoard(boardObject, size);


        }
        
    }
    public class Board
    {
        public Board() { }
        public char[] getBoard(int size = 10)
        {
            char[] board = new char[size * size];
            char[] square = ['■', '□'];

            for (int i = 0; i < board.Length; i++)
            {
                if (size % 2 == 0)
                {
                    //If the size is uneven we reverse the order of squares every new row so it lines up correctly.
                    if (i != 0 && i % size == 0)
                    {
                        square = square.Reverse().ToArray();
                    }
                }
                //Add squares to board alternating between white and black squares.
                board[i] = square[i % 2];
            }
            return board;
        }

        public void printBoard(char[] board, int size)
        {
            for (int i = 0; i < board.Length; i++)
            {
                Console.Write(board[i]);
                //Creates a new row after printing enough squares to accomodate for the size of the board.
                if ((i + 1) % size == 0)
                {
                    Console.WriteLine();
                }
            }
        }
    }
}
