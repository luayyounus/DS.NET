# Tic Tac Toe Console Game! 

Tic-tac-toe is a paper-and-pencil game for two players, X and O, who take turns marking the spaces in a 3×3 grid. The player who succeeds in placing three of their marks in a horizontal, vertical, or diagonal row wins the game.

#### The game is broken down into two Classes in addition to the main Execution Class


1. Tic Tac Toe Class 
 - Drawing Board
 - Switching Players
 - Setting Markers
 - Deciding Winner
2. Game Class
- Where the opponents take turns during the game
3. Main Program Class
- Where the main program executes the game

#### Tic-Tac-Toe Class
```java
public class TicTacToe
{
    // 2D character board 3x3 
    public char[,] Board = new char[3, 3];

    // Player One name
    public string PlayerOne { get; set; }

    // Player Two name
    public string PlayerTwo { get; set; }

    // Specifying which player's turn is it
    public int CurrentPlayer { get; set; }

    // X - O ... or any other character
    public char Marker1 { get; set; }
    public char Marker2 { get; set; }

    // Number of total plays in the current game
    public int Plays { get; set; }

    // Initialize every box with a number from 1-9
    public void Init()
    {
        int counter = 48;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                // Get character for an int
                Board[i, j] = (char)++counter;
            }
        }

        // Setting the first player starting the game
        CurrentPlayer = 1;

        // Reseting the number of plays at the beginning of the game
        Plays = 0;
    }

    // Switch a player when the other player draw a symbol
    public void SwitchPlayers()
    {
        // Switching player
        CurrentPlayer = (CurrentPlayer == 1) ? 2 : 1;
        Plays++;
    }

    public bool PlaceMarker(int play)
    {
        for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
            {
                if (Board[i, j] == (char)play + 48)
                {
                    Board[i, j] = (CurrentPlayer == 1) ? Marker1 : Marker2;
                    return true;
                }
            }

        return false;
    }

    public bool Winner()
    {
        // Checking Rows
        char current = ' ';
        for (int i = 0; i < 3; i++)
        {
            int j = 0;
            for (j = 0; j < 3; j++)
            {
                if (!char.IsLetter(Board[i, j]))
                    break;
                if (j == 0)
                    current = Board[i, j];
                else if (current != Board[i, j])
                    break;
                if (j == 2)
                    return true; // The winner
            }
        }

        // Checking Columns
        for (int i = 0; i < 3; i++)
        {
            current = ' ';
            int j = 0;
            for (j = 0; j < 3; j++)
            {
                if (!char.IsLetter(Board[j, i]))
                    break;
                if (j == 0)
                    current = Board[j, i];
                else if (current != Board[j, i])
                    break;
                if (j == 2) // The winner
                    return true;
            }
        }

        // Checking Diagonals matches
        current = Board[0, 0];
        if (char.IsLetter(current) && Board[1, 1] == current && Board[2, 2] == current)
            return true;

        current = Board[2, 0];
        if (char.IsLetter(current) && Board[1, 1] == current && Board[0, 2] == current)
            return true;

        return false;
    }

    // Draw the board with the current state
    public string DrawBoard()
    {
        StringBuilder sb = new StringBuilder("Game Board \n");
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
                sb.Append("|" + Board[i, j] + "|");

            sb.Append("\n");
        }
        return sb.ToString();
    }
}

```


#### Game Class

```java
public static class Game
{
    public static void Play()
    {
        TicTacToe game = new TicTacToe();

        Console.WriteLine("Welcome to Tic Tac Toe Game!");

        Console.WriteLine("Enter the first player's name:");
        game.PlayerOne = Console.ReadLine();

        Console.WriteLine("Enter the second player's name:");
        game.PlayerTwo = Console.ReadLine();

        bool markerValid = false;

        while (!markerValid)
        {
            Console.WriteLine("Select a letter as " + game.PlayerOne + "'s marker:");

            string marker = Console.ReadLine();

            if (marker.Length == 1 && char.IsLetter(marker.ToCharArray()[0]))
            {
                markerValid = true;
                game.Marker1 = marker.ToCharArray()[0];
            }
            else Console.WriteLine("Invalid marker, try again with another character");
        }

        markerValid = false;

        while (!markerValid)
        {
            Console.WriteLine("Select any letter as " + game.PlayerTwo + "'s marker: ");
            string marker = Console.ReadLine();

            if (marker.Length == 1 && char.IsLetter(marker.ToCharArray()[0]))
            {
                markerValid = true;
                game.Marker2 = marker.ToCharArray()[0];
            }
            else Console.WriteLine("Invalid marker, try again with another character");
        }

        bool continuePlaying = true;

        while (continuePlaying)
        {
            // Initializing the board
            game.Init();

            Console.WriteLine("The rules are well known. Or you will figure it out along the way :)");

            // Draw the board with current state
            Console.WriteLine(game.DrawBoard());

            // initializing the player's name to none
            string player = null;

            while (!game.Winner() && game.Plays < 9)
            {
                // setting the current player's name
                player = game.CurrentPlayer == 1 ? game.PlayerOne : game.PlayerTwo;

                bool validPick = false;

                while (!validPick)
                {
                    Console.WriteLine("It is " + player + "'s turn. Pick a square/box:");

                    string square = Console.ReadLine();

                    if (square.Length == 1 && char.IsDigit(square.ToCharArray()[0]))
                    {
                        int pick = 0;

                        try
                        {
                            pick = int.Parse(square);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }

                        validPick = game.PlaceMarker(pick);
                    }

                    if (!validPick)
                        Console.WriteLine("This Square can not be selected... Please Try again");
                }

                // Current player market a square -> switch to the other player
                game.SwitchPlayers();

                Console.WriteLine(game.DrawBoard());
            }

            if (game.Winner())
                Console.WriteLine("Congrats! " + player + " wins the game!");
            else
                Console.WriteLine("Tada! Game Over - It's a Draw");

            Console.WriteLine("Want to Play again? Type (Y/N)");

            string choice = Console.ReadLine();

            if (!(choice.ToUpper() == "Y")) continuePlaying = false;
        }
    }
}
```