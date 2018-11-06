using System;
using System.Linq;

class Game
{
    public string[] board = { "1", "2", "3", "4", "5", "6", "7", "8", "9"};
    public string[] players = { "X", "Y" };
    public string turn = String.Empty;
    public bool end = false;
    
    public void Turn()
    {
        foreach (string i in players)
        {
            turn = i;
            Move(i);
        }
        
    }
    public void Move(string player)
    {
        Console.WriteLine(ShowBoard());
        Console.WriteLine("Where do would you like to go " + player + "?");
        var move = Console.ReadLine();
        PlaceMove(move);

    }
    public void PlaceMove(string move)
    {
        try
        {
            var x = Int32.Parse(move);
            if (board[x - 1] != move)
            {
                Console.WriteLine("Spot taken... Try again!");
                Move(turn);
            }
            board[x - 1] = turn;
            CheckWin();
        }
        catch
        {
            Console.WriteLine("Not a valid board spot... Try again!");
            Move(turn);
        }
    }
    public void CheckWin()
    {
        string[] win_rows = { "1,2,3", "4,5,6", "7,8,9", "1,4,7", "1,5,9", "2,5,8", "3,6,9", "3,5,6", "7,5,3" };
        foreach (string i in win_rows)
        {
            string[] rows = i.Split(',');
            if(CheckRow(rows[0], rows[1], rows[2]) == true)
            {
                Console.WriteLine(ShowBoard());
                Console.WriteLine(turn + " wins!");
                Console.WriteLine("Press any key to escape...");
                Console.ReadKey();
                Environment.Exit(0);
            }
        }
    }
    public bool CheckRow(string move1, string move2, string move3)
    {
        string[] moves = { board[Int32.Parse(move1) - 1], board[Int32.Parse(move2) - 1], board[Int32.Parse(move3) - 1] };
        var item = moves.FirstOrDefault();
        bool match = moves.Skip(1).All(i => i.ToLower() == item.ToLower());
        if (match == true)
        {
            return true;
        }
        return false;
    }
    public string ShowBoard()
    {
        return String.Format("\n{0}|{1}|{2}\n-----\n{3}|{4}|{5}\n-----\n{6}|{7}|{8}\n", board[0],board[1], board[2], board[3], board[4], board[5], board[6], board[7], board[8]);
    }
}

public class Constructor
{
    public static void Main()
    {
        Game gameObject = new Game();
        while (gameObject.end == false)
        {
            gameObject.Turn();
        }
    }
}
