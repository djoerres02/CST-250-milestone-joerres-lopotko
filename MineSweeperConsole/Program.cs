using MineSweeperClasses;

static void Main(string[] args)
{
    Console.WriteLine("Hello, welcome to Minesweeper");

    // size 10 and difficulty 0.1
    Board board = new Board(10, 10);
    Console.WriteLine("Here is the answer key for the first board:");
    PrintAnswers(board);

    // size 15 and difficulty 0.15
    board = new Board(15, 15);
    Console.WriteLine("\nHere is the answer key for the second board:");
    PrintAnswers(board);

    Console.WriteLine("\nPress Enter to exit...");
    Console.ReadLine();
}

/// <summary>
/// Print answer key to board
/// </summary>
/// <param name="board"></param>
static void PrintAnswers(Board board)
{
    // Loop through each row and column of board's cells
    for (int i = 0; i < board.Size; i++)
    {
        for (int j = 0; j < board.Size; j++)
        {
            Cell cell = board.Cells[i, j];

            // Write B is for cells with a bomb
            if (cell.IsBomb)
            {
                Console.Write("B ");
            }
            else
            {
                Console.Write($"{cell.NumberOfBombNeighbors} ");
            }
        }
        // After printing a row, move to next line.
        Console.WriteLine();
    }
}
