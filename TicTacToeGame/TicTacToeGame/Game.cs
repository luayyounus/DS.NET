using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToeGame
{
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
}
