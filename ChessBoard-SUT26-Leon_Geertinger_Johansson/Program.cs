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
                    //Throws an exception if parse fails or size is not within 1-100
                    size = int.Parse(Console.ReadLine());
                
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
            char blackSquare;
            while (true)
            {
                Console.WriteLine("Har ska svarta rutor se ut? (En bokstav eller karaktär)");
                //Use tryparse since we only care if user input is a 'char'
                if (char.TryParse(Console.ReadLine(), out blackSquare))
                {
                    break;
                }
                Console.WriteLine("Vänligen ange exakt en bokstav eller karaktär.");
            }

            char whiteSquare;
            while (true)
            {
                Console.WriteLine("Hur ska vita rutor se ut? (En bokstav eller karaktär)");
                if (char.TryParse(Console.ReadLine(), out whiteSquare))
                {
                    break;
                }
                Console.WriteLine("Vänligen ange exakt en bokstav eller karaktär.");
            }

            Board board = new Board(size, blackSquare, whiteSquare);
            

            Console.WriteLine("Vart vill du placera en pjäs? (t.ex '2 3')");
            
            while (true)
            {
                try
                {
                
                    string[] stringCoordinates = Console.ReadLine().Split();
                    if (stringCoordinates.Length != 2)
                    {
                        throw new Exception();
                    }
                    
                    int x = int.Parse(stringCoordinates[0]);
                    int y = int.Parse(stringCoordinates[1]);

                    //Checks if coordinates is within board size
                    if (x < 0 || y < 0 || x > board.size || y > board.size)
                    {
                        throw new Exception();
                    }

                    int[] coordinates = { x, y };

                    board.placePiece(coordinates);
                   
                    board.printBoard();

                    break;
                }
                catch
                {
                    Console.WriteLine("Vänligen ange 2 giltiga nummer separerade med ett mellanslag.");
                    Console.WriteLine($"Nummer bör vara mellan 0 - {board.size - 1}");
                }
            }
            
            


        }
        
    }
    public class Board
    {
        public int size { get; private set; } = 10;
        public char[] board {  get; set; }
        public char whiteSquare { get; set; } /*= '■';*/
        public char blackSquare { get; set; } /*= '□';*/
        public Board(int size, char blackSquare, char whiteSquare) {
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
        
        public void placePiece(int[] coordinates)
        {
            //Calculates index as if board was a 2D array.
            int index = coordinates[0] + (coordinates[1] * this.size);
            board[index] = 'X';
        }
    }
}
