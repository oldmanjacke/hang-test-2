using System;
using System.Collections.Generic;
using System.Text;
namespace hang_test_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Random randow = new Random();

            string[] color = { "Blue", "Black", "Red", "Yellow", "Green", "grey", "White", "Purple", "Orange", "Rainbow" , "Gold", "Silver" };

            var rand = randow.Next(color.Length);
            var secretWord = color[rand];
            var secretWordUppercase = secretWord.ToUpper();

            StringBuilder underscore = new StringBuilder(secretWord.Length);
            for (int i = 0; i < secretWord.Length; i++)
                underscore.Append("_");

            List<char> correctGuesses = new List<char>();
            List<char> allGuessesWords = new List<char>();
            StringBuilder incorrectGuesses = new StringBuilder();
            List<string> guessedWords = new List<string>();

            bool won = false;
            int lettersRevealed = 0;
            int lives = 10;

            string input;
           // string inputWord;
            char guess;
            string guesseWord;

            Console.WriteLine("***********");
            Console.WriteLine("welcome to hangman world");
            Console.WriteLine("*********");

            while (!won && lives > 0)
            {
                Console.WriteLine("1. guess a letter.\n2. guess the whole word.\n3. Quit.\n\n");
                var choose = Console.ReadLine();

                if (choose == "1")
                {
                    Console.Write("\n\n guess a letter: \t" + underscore.ToString());
                    Console.Write("\t\t Incorrect letters: " + incorrectGuesses + "\n\n\n");
                    input = Console.ReadLine().ToUpper();
                    guess = input[0];

                    if (secretWordUppercase.Contains(guess))
                    {
                        correctGuesses.Add(guess);

                        for (int i = 0; i < secretWord.Length; i++)
                        {
                            if (secretWordUppercase[i] == guess)
                            {
                                underscore[i] = secretWord[i];
                                lettersRevealed++;
                            }
                        }
                        if (lettersRevealed == secretWord.Length)
                        {
                            won = true;
                            Console.WriteLine(underscore.ToString());
                            Console.WriteLine("Congrats - " + secretWord + "is the correct word!");
                        }


                    }
                    else
                    {
                        if (allGuessesWords.Contains(guess))
                        {
                            allGuessesWords.Add(guess);
                        }
                        else
                        {
                            incorrectGuesses.Append(guess);
                            allGuessesWords.Add(guess);
                            lives--;
                            Console.WriteLine(" guess left: " + lives + "\n");
                        }
                        if (lives == 0)
                        {
                            Console.WriteLine("to bad" + secretWord + "was the right word!");
                        }
                    }
                }

                else if (choose == "2")
                {
                    Console.WriteLine("\n\n guess the word: \t" + underscore.ToString() + "\t");
                    input = Console.ReadLine().ToUpper();
                    guesseWord = input;

                    if (secretWordUppercase.Contains(guesseWord))
                    {
                        won = true;
                        Console.WriteLine(underscore.ToString());
                        Console.WriteLine("congrats! -" + secretWord + " is the right word!");
                        Console.WriteLine("Thank you for playing this hangman!");
                    }
                    else
                    {
                        lives--;
                        Console.WriteLine("sorry wrong word! - try again");

                        if (lives == 0)
                        {
                            Console.WriteLine("to bad you lost!" + secretWord + " was the right word!");
                            Console.WriteLine("thank you for playing this hangman!");
                        }
                    }
                }
                 else if (choose == "3")
                {
                    Console.WriteLine("\n bye!");
                    Console.WriteLine("thank you for playing!");
                    break;
                }
                else
                {
                    Console.WriteLine("Hello key smasher!\n Better luck next time!");
                    break;
                }

            }

        }
    }
}
