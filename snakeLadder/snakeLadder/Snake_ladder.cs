using System;

namespace snakeLadder
{

    class SnL
    {

        // Class Constants

        const int startPos = 0;
        const int EndPos = 100;

        // Function to generate random roll of a dice with 6 faces
        public int diceRoll(int min, int max)
        {
            Random roll = new Random();
            int value = roll.Next(min, max);
            return value;
        }

        // Function for USE CASE - 1

        public void displayStart()
        {
            Console.WriteLine(" The starting position of the player is : " + startPos);
        }

        // Function for USE CASE - 2

        public int displayRoll()
        {
            int roll_out = diceRoll(1, 7);
            Console.WriteLine("The outcome of the current dice roll is : " + roll_out);
            return roll_out;
        }

        // Function for USE CASE - 3

        public int playDecision(int outcome)
        {
            Random choice = new Random();
            int val = choice.Next(1, 4);

            if (val == 1)
            {
                Console.WriteLine("Bitten by Snake ");
                return -outcome;  // Snake Condition
            }
            else if (val == 2)
            {
                Console.WriteLine(" No play");
                return 0;           // No play Condition
            }
            else
            {
                Console.WriteLine("Climbing the ladder");
                return outcome;     // Ladder Condition
            }
        }

        // Function for USE CASE - 4 , 5 , 6

        public void gameSimul()
        {
            displayStart();
            int currPos = startPos;
            int timesPlayed = 0;
            while (currPos < EndPos)
            {
                int curr_roll = displayRoll();
                timesPlayed++;
                int newStep = playDecision(curr_roll);
                if (currPos + newStep < startPos)
                {
                    Console.WriteLine(" Sorry Back at the Start Position");
                    currPos = 0;
                }
                else if (currPos + newStep > EndPos)
                {
                    Console.WriteLine(" Sorry cannot go forward");
                    currPos += 0;
                }
                else
                {
                    currPos += newStep;
                }

                Console.WriteLine(" The current position of the player is : " + currPos + "\n\n");
            }
            Console.WriteLine("The Dice was played " + timesPlayed + " times.");

            Console.WriteLine("The player has won. ");
        }
        
        // Function for player movements

        public int playerMoves(int currPos, ref int timesplayed)
        {
            timesplayed++;
            int curr_roll = displayRoll();
            int newStep = playDecision(curr_roll);
            if (currPos + newStep < startPos)
            {
                Console.WriteLine(" Sorry Back at the Start Position");
                currPos = 0;
            }
            else if (currPos + newStep > EndPos)
            {
                Console.WriteLine(" Sorry cannot go forward");
                currPos += 0;
            }
            else
            {
                currPos += newStep;
            }

            return currPos;
        }
        
        // Function for USE CASE - 7
        public void gameSimul2p()
        {
            displayStart();
            int currPos1 = startPos;
            int currPos2 = startPos;
            int timesPlayed1 = 0;
            int timesPlayed2 = 0;
            bool flag = true;
            while (currPos1 < EndPos && currPos2 < EndPos)
            {
                if (flag)
                {
                    Console.WriteLine("Player 1 turn ");
                    int currPos1_temp = playerMoves(currPos1,ref timesPlayed1);
                    
                    Console.WriteLine(" The current position of player1 is : " + currPos1_temp + "\n\n");
                    if (currPos1_temp == EndPos)
                    {
                        Console.WriteLine("The Player 1 won in " + timesPlayed1 + " rolls.");
                        break;
                    }

                    if (currPos1_temp > currPos1)
                    {
                        currPos1= currPos1_temp;
                        flag = true;
                       
                    }
                    else
                    {
                        currPos1 = currPos1_temp;
                        flag= false;
                    }
                    
                }
                else
                {
                    Console.WriteLine("Player 2 turn");
                    int currPos2_temp = playerMoves(currPos2,ref timesPlayed2);
                    Console.WriteLine(" The current position of player2 is : " + currPos2_temp + "\n\n");
                    if (currPos2 == EndPos)
                    {
                        Console.WriteLine("The Player 2 won in " + timesPlayed2 + " rolls.");
                        break;
                    }

                    if (currPos2_temp > currPos2)
                    {
                        currPos2 = currPos2_temp;
                        flag= false;
                    }
                    else
                    {
                        currPos2 = currPos2_temp;
                        flag = true;
                    }
                   
                }

            }

            Console.WriteLine("\nThe Game ended Successfully");
        }
    }
}