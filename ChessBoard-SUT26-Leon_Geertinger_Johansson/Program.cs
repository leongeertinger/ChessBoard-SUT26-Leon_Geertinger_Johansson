Console.OutputEncoding = System.Text.Encoding.UTF8;
namespace ChessBoard_SUT26_Leon_Geertinger_Johansson
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] getBoard(int size = 10)
            {
                char[] board = new char[size * size];
                char[] square = ['■', '□'];

                for (int i = 0; i < board.Length; i++)
                {
                    if (size % 2 == 0)
                    {
                        if (i != 0 && i % size == 0)
                        {
                            square = square.Reverse().ToArray();
                        }
                    }
                    board[i] = square[i % 2];
                }
                return board;
            }
        }
    }
}
