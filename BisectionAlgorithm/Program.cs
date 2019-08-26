using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace BisectionAlgorithm
{
    class Program
    {
        static int startingPoint = 1; //starting point
        static int topValue = 100; //default values
        static int middle;
        static void Main(string[] args)
        {
            Console.WriteLine("Bisection Algorithm.Main()");
            gameChoice();

        }
        static void gameChoice()
        {
            bool valid;
            int choice;
            Console.WriteLine("Who should guess the number?");
            Console.WriteLine("1 : User or 2 : Computer");
            do
            {
                valid = int.TryParse(Console.ReadLine(), out choice);
                if (!valid || choice < 1 || choice > 3)
                {
                    Console.WriteLine("Invalid input");
                    valid = false;
                }
            } while (!valid);
            if (choice == 1)
            {
                humanGame();
            }
            else if (choice == 2)
            {
                computerGame();
            }
            else if (choice == 3)
            {
                bisectionalAlgorithm();
            }
        }
        static void bisectionalAlgorithm()
        {
            //bool valid;
            //bool userGuessedCorrectly;
            //int userGuess;
            //Console.WriteLine("What range do you want the computer to guess from?");
            //Console.Write($"{startingPoint} through ");
            //do
            //{
            //    valid = int.TryParse(Console.ReadLine(), out topValue);
            //    if (!valid)
            //    {
            //        Console.WriteLine("Invalid input");
            //    }
            //    else if (topValue <= startingPoint)
            //    {
            //        Console.WriteLine($"Range must bigger than {startingPoint}");
            //        valid = false;
            //    }
            //} while (!valid);
            //List<int> rangeOfNums = populateList(topValue);
            //int randValue = computerPicksRandom(rangeOfNums);
            //if (randValue > middle)
            //{
            //    Console.WriteLine($"Value is higher than {middle}");
            //    startingPoint = middle;
            //    populateUpperHalf(out rangeOfNums);
            //    middle = findMiddle(rangeOfNums[0], rangeOfNums[rangeOfNums.Count - 1]);
            //    Console.WriteLine("Range Of Num is now");
            //    foreach (var item in rangeOfNums)
            //    {
            //        Console.Write($"{item},");
            //    }
            //    Console.WriteLine($"\nMiddle is {middle}");
            //}
            //    else if (randValue < middle)
            //    {
            //        Console.WriteLine($"Value is lower than {middle}");
            //        //populates lowerHalf
            //        topValue = middle;
            //        populateLowerHalf(out rangeOfNums);
            //        middle = findMiddle(rangeOfNums[0], rangeOfNums[rangeOfNums.Count - 1]);
            //        Console.WriteLine("Range Of Num is now");
            //        foreach (var item in rangeOfNums)
            //        {
            //            Console.Write($"{item},");
            //        }
            //        Console.WriteLine($"\nMiddle is {middle}");
            //    }
            //} while (randValue != middle);
            //if (randValue == middle)
            //{
            //    Console.WriteLine($"Computer chose {randValue}");
            //    Console.WriteLine($"The value searched for, {randValue}, has been found ");
            //    exitGame();
            //}
        }
        static List<int> populateList(int topValue)
        {
            List<int> numberRange = Enumerable.Range(startingPoint, topValue).ToList();
            return numberRange;
        }
        static void humanGame()
        {
            bool valid;
            bool userGuessedCorrectly;
            int userGuess;
            Console.WriteLine("What range do you want the computer to guess from?");
            Console.Write($"{startingPoint} through ");
            do
            {
                valid = int.TryParse(Console.ReadLine(), out topValue);
                if (!valid)
                {
                    Console.WriteLine("Invalid input");
                }
                else if (topValue <= startingPoint)
                {
                    Console.WriteLine($"Range must bigger than {startingPoint}");
                    valid = false;
                }
            } while (!valid);
            List<int> rangeOfNums = populateList(topValue);
            int randValue = computerPicksRandom(rangeOfNums);
            do
            {
                Console.WriteLine("Guess the number");
                userGuessedCorrectly = int.TryParse(Console.ReadLine(), out userGuess);
                if (!userGuessedCorrectly)
                {
                    Console.WriteLine("Invalid input");
                }
                if (userGuess < randValue)
                {
                    Console.WriteLine("Guess was too low");
                    userGuessedCorrectly = false;
                }
                else if (userGuess > randValue)
                {
                    Console.WriteLine("Guess was too high");
                    userGuessedCorrectly = false;
                }
                else if (userGuess == randValue)
                {
                    userGuessedCorrectly = true;
                    Console.WriteLine($"You got it! The computer chose {randValue}");
                    exitGame();
                }


            } while (!userGuessedCorrectly);



        }
        static int computerPicksRandom(List<int> rangeOfNums)
        {
            int randomValue;
            Random r = new Random();
            randomValue = rangeOfNums[r.Next(startingPoint, topValue)];

            return randomValue;

        }
        static void computerGame()
        {
            int userGuess;
            bool valid;
            List<int> rangeOfNums = populateList(topValue);
            Console.WriteLine($"Choose a number between {startingPoint} and {topValue}");
            do
            {
                valid = int.TryParse(Console.ReadLine(), out userGuess);
                if (!valid || userGuess < startingPoint || userGuess > topValue)
                {
                    Console.WriteLine("Invalid Input");
                    valid = false;
                }
            } while (!valid);
            Console.WriteLine($"Computer will try to guess your number");
            middle = findMiddle(rangeOfNums[0], rangeOfNums[rangeOfNums.Count - 1]);
            do
            {
                int computerguess = middle;
                Console.WriteLine($"Computer guesses {computerguess}");
                int result;
                Console.WriteLine("1: Too high , 2: Too Low , 3: Correct Answer");
                valid = int.TryParse(Console.ReadLine(), out result);
                if (!valid || result < 1 || result > 3)
                {
                    Console.WriteLine("Invalid input");
                }
                switch (result)
                {
                    case 1:
                        topValue = middle;
                        populateLowerHalf(out rangeOfNums);
                        middle = findMiddle(rangeOfNums[0], rangeOfNums[rangeOfNums.Count - 1]);
                        valid = false;
                        break;
                    case 2:                        
                        startingPoint = middle;
                        populateUpperHalf(out rangeOfNums);
                        middle = findMiddle(rangeOfNums[0], rangeOfNums[rangeOfNums.Count - 1]);
                        valid = false;
                        break;
                    case 3:
                        Console.WriteLine($"Computer successfully guessed {userGuess}");
                        exitGame();
                        break;
                    default:
                        break;
                }
            } while (!valid);
                    
        }

        static int findMiddle(int startpoint, int endingpoint)
        {
            middle = (startpoint+endingpoint) / 2;
            return middle;
        }

        static void populateUpperHalf(out List<int> rangeOfNums)
        {
            List<int> newRangeOfNums = new List<int>();
            for (int i = middle + 1; i <= topValue; i++)
            {
                newRangeOfNums.Add(i);
            }
            rangeOfNums = newRangeOfNums;
        }

        static void populateLowerHalf(out List<int> rangeOfNums)
        {
            List<int> newRangeOfNums = new List<int>();
            for (int i = startingPoint; i < middle; i++)
            {
                newRangeOfNums.Add(i);
            }
            rangeOfNums = newRangeOfNums;
        }
        static void exitGame()
        {
            Console.WriteLine("Thanks for playing!");
            Thread.Sleep(500);
            Console.WriteLine("Press anything to exit");
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}
