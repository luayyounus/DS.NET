using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToeGame
{
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
                        Board[i,j] = (CurrentPlayer == 1) ? Marker1 : Marker2;
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
                    if (!char.IsLetter(Board[i,j]))
                        break;
                    if (j == 0)
                        current = Board[i, j];
                    else if (current != Board[i,j])
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
                    if (!char.IsLetter(Board[j,i]))
                        break;
                    if (j == 0)
                        current = Board[j,i];
                    else if (current != Board[j,i])
                        break;
                    if (j == 2) // The winner
                        return true;
                }
            }

            // Checking Diagonals matches
            current = Board[0,0];
            if (char.IsLetter(current) && Board[1,1] == current && Board[2,2] == current)
                return true;

            current = Board[2,0];
            if (char.IsLetter(current) && Board[1,1] == current && Board[0,2] == current)
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
}

