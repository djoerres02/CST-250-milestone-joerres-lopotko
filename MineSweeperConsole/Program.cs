using MineSweeperClasses;

static void Main(string[] args)
{
    Console.WriteLine("Hello, welcome to Minesweeper");
    // size 10 and difficulty 0.1
    Board board = new Board(10, 0.1f);
    Console.WriteLine("Here is the answer key for the first board");
    PrintAnswers(board);

    // size 15 and difficulty 0.15
    board = new Board(15, 0.15f);
    Console.WriteLine("Here is the answer key for the second board");
    PrintAnswers(board);
}

