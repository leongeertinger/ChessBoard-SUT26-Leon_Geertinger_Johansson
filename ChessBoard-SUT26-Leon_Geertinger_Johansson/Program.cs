using System.Drawing;

namespace ChessBoard_SUT26_Leon_Geertinger_Johansson
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;


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
            Console.WriteLine("Har ska svarta rutor se ut? ");
            char blackSquare = char.Parse(Console.ReadLine());

            Console.WriteLine("Hur ska vita rutor se ut? ");
            char whiteSquare = char.Parse(Console.ReadLine());

            Board board = new Board(size, blackSquare, whiteSquare);
            
            board.printBoard();


        }
        
    }
    public class Board
    {
        private int size { get; set; } = 10;
        public char[] board {  get; set; }
        public char whiteSquare { get; set; }
        public char blackSquare { get; set; }
        public Board(int size, char blackSquare = '□', char whiteSquare = '■') {
            this.size = size;
            this.blackSquare = blackSquare;
            this.whiteSquare = whiteSquare;
            this.board = getBoard(size);
        }
        public char[] getBoard(int size)
        {
            char[] board = new char[size * size];
            char[] square = [this.whiteSquare, this.blackSquare];

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
        
        public void printBoard()
        {
            for (int i = 0; i < this.board.Length; i++)
            {
                Console.Write(this.board[i]);
                //Creates a new row after printing enough squares to accomodate for the size of the board.
                if ((i + 1) % this.size == 0)
                {
                    Console.WriteLine();
                }
            }
        }
    }
}
