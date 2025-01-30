using GameOfLife;
using System;

namespace GameOfLife
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Welcome to Conway's Game of Life (Simple Console Version)\n");

            int rows = ReadIntFromConsole("Enter number of rows: ");
            int cols = ReadIntFromConsole("Enter number of columns: ");
            int numberOfLivingCells = ReadIntFromConsole("Enter number of initial live cells: ");

            Generation generation = new Generation(rows, cols, numberOfLivingCells);
            Console.WriteLine("\nInitial board:");
            DisplayBoard(generation);

            while (true)
            {
                Console.Write("\nPress [Enter] for next generation, type a number for multiple steps, or 'q' to quit: ");
                string userInput = Console.ReadLine();

                if (string.Equals(userInput, "q", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Goodbye!");
                    break;
                }
                else if (string.IsNullOrWhiteSpace(userInput))
                {
                    generation = generation.NextGeneration();
                    DisplayBoard(generation);
                }
                else
                {
                    if (int.TryParse(userInput, out int steps))
                    {
                        for (int i = 0; i < steps; i++)
                        {
                            generation = generation.NextGeneration();
                        }
                        DisplayBoard(generation);
                    }
                    else
                    {
                        Console.WriteLine("Unrecognized input. Press Enter to step one generation, or type an integer, or 'q' to quit.");
                    }
                }
            }
        }

        private static int ReadIntFromConsole(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                if (int.TryParse(input, out int value))
                {
                    return value;
                }
                Console.WriteLine("Invalid number. Try again.");
            }
        }

        private static void DisplayBoard(Generation generation)
        {
            for (int r = 0; r < generation.Rows; r++)
            {
                for (int c = 0; c < generation.Cols; c++)
                {
                    Console.Write(generation.IsAlive(r, c) ? '*' : '.');
                }
                Console.WriteLine();
            }
        }
    }
}
