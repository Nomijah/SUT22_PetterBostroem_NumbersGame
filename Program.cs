// Petter Boström SUT22
using System;

namespace NumbersGame2
{
    internal class Program
    {
        // Create function for checking if number is correct
        public static int CheckGuess(int UserGuess, int RndNum)
        {
            // Return values for correct guess, too low and too high
            int checkValue;
            if (UserGuess == RndNum)
                checkValue = 0;
            else if (UserGuess < RndNum)
            {
                checkValue = 1;
                // Check if guess was close to correct
                if (UserGuess == RndNum - 1 || UserGuess == RndNum - 2 ||
                    UserGuess == RndNum + 1 || UserGuess == RndNum + 2)
                    checkValue = 11;
            }
            else
            {
                checkValue = 2;
                // Check if guess was close to correct
                if (UserGuess == RndNum - 1 || UserGuess == RndNum - 2 ||
                    UserGuess == RndNum + 1 || UserGuess == RndNum + 2)
                    checkValue = 21;
            }
            return checkValue;
        }
        static void Main(string[] args)
        {
            // Create loop for restarting game
            bool play = true;
            while (play)
            {
                // Create loop until correct choice is made
                bool startGame = true;
                int userChoice = 0;
                while (startGame)
                {
                    // Present the user with three difficulties
                    Console.WriteLine("\n\tInnan vi börjar, välj en " +
                        "svårighetsgrad." +
                        "\n\t[1] Lätt" +
                        "\n\t[2] Medel" +
                        "\n\t[3] Svår" +
                        "\n\t[4] Eget val");
                    Console.Write("\t");
                    string userInput = Console.ReadLine();
                    // Check if userInput is not a number
                    while (!Int32.TryParse(userInput, out userChoice))
                    {
                        Console.WriteLine("\tAnvänd endast siffror, försök " +
                            "igen:");
                        Console.Write("\t");
                        userInput = Console.ReadLine();
                    }
                    userChoice = Convert.ToInt32(userInput);
                    // Check if userInput is not an integer between 1 and 4
                    if (userChoice < 1 || userChoice > 4)
                    {
                        Console.WriteLine("\tFelaktigt val! Skriv en siffra " +
                            "mellan 1-4");
                    }
                    else
                    {
                        startGame = false;
                    }
                }
                // Program different values for the difficulty levels
                int triesAmount;
                int maxNumber;
                
                if (userChoice == 1)
                {
                    triesAmount = 6;
                    maxNumber = 21;
                }
                else if (userChoice == 2)
                {
                    triesAmount = 5;
                    maxNumber = 51;
                }
                else if (userChoice == 3)
                {
                    triesAmount = 4;
                    maxNumber = 101;
                }
                else
                {
                    Console.WriteLine("\tHur många tal vill du gissa på?");
                    Console.Write("\t");
                    string userInput = Console.ReadLine();
                    int userNumber;
                    while (!Int32.TryParse(userInput, out userNumber))
                    {
                        Console.WriteLine("\tAnvänd enbart siffror, " +
                            "försök igen.");
                        Console.Write("\t");
                        userInput = Console.ReadLine();
                    }
                    maxNumber = userNumber + 1;
                    Console.WriteLine("\tHur många försök vill du ha?");
                    Console.Write("\t");
                    string userInput2 = Console.ReadLine();
                    int userGuesses;
                    while (!Int32.TryParse(userInput2, out userGuesses))
                    {
                        Console.WriteLine("\tAnvänd enbart siffror, " +
                            "försök igen.");
                        Console.Write("\t");
                        userInput = Console.ReadLine();
                    }
                    triesAmount = userGuesses;
                }
                // Write the conditions of the game
                Console.WriteLine("\n\tVälkommen! \n\n\tJag tänker på ett tal" +
                    $" mellan 1 och {maxNumber - 1}. " +
                    $"Kan du gissa vilket? Du får {triesAmount} försök.");
                // Create random number
                Random rnd = new Random();
                int rndNum = rnd.Next(1, maxNumber);
                // Create loop with a maximum of rounds depending on difficulty
                int tries = 0;
                while (tries < triesAmount)
                {
                    // Ask user to input guess
                    Console.WriteLine("\tSkriv det tal du vill gissa på: ");
                    Console.Write("\t");
                    int userInput2 = Convert.ToInt32(Console.ReadLine());
                    // Check the guess
                    int checkedValue = CheckGuess(userInput2, rndNum);
                    // Switch for different answers
                    switch (checkedValue)
                    {
                        case 0:
                            // Congratulate user on guessing the right number
                            Console.WriteLine("\tWoho! Du gjorde det!");
                            /* Set value of int tries to tries + 1 to end loop
                             * and avoid displaying failure message */
                            tries = triesAmount + 1;
                            break;
                        case 1:
                            // Randomize answers
                            Random rndMsg = new Random();
                            int displayMsg = rndMsg.Next(1, 4);
                            if (displayMsg == 1)
                                Console.WriteLine("\tTyvärr, du gissade för " +
                                    "lågt.");
                            else if (displayMsg == 2)
                                Console.WriteLine("\tNej, det var för lite.");
                            else if (displayMsg == 3)
                                Console.WriteLine("\tTalet är större än så");
                            tries++;
                            break;
                        case 11:
                            Console.WriteLine("\tTyvärr, du gissade för lågt, "+
                                " men det bränns!");
                            tries++;
                            break;
                        case 2:
                            // Randomize answers
                            Random rndMsg2 = new Random();
                            int displayMsg2 = rndMsg2.Next(1, 4);
                            if (displayMsg2 == 1)
                                Console.WriteLine("\tTyvärr, du gissade för " +
                                    "högt.");
                            else if (displayMsg2 == 2)
                                Console.WriteLine("\tNej, det var för mycket.");
                            else if (displayMsg2 == 3)
                                Console.WriteLine("\tTalet är mindre än så");
                            tries++;
                            break;
                        case 21:
                            Console.WriteLine("\tTyvärr, du gissade för högt," +
                                " men det bränns!");
                            tries++;
                            break;
                    }
                }
                // If user has guessed incorrectly too many times, end game
                if (tries == triesAmount)
                {
                    Console.WriteLine("\tTyvärr, du lyckades inte gissa talet" +
                        $" på {triesAmount} försök!");
                }
                // Check if user wants to play again
                Console.WriteLine("\n\tVill du spela igen? [J/N]");
                Console.Write("\t");
                string playAgain = Console.ReadLine();
                while (playAgain.ToUpper() != "J" && playAgain.ToUpper() != "N")
                {
                    Console.WriteLine("\tFelaktigt val, försök igen. J för ja" +
                        " eller N för nej.");
                    Console.Write("\t");
                    playAgain = Console.ReadLine();
                }
                if (playAgain.ToUpper() == "N")
                    play = false;
            }

            Console.WriteLine("\tTack för att du spelade!");
            Console.ReadKey();
        }
    }
}
