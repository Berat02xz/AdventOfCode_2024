using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode_2024.Day_6
{
    public class Puzzle6
    {
        public static void Solution(string[] args)
        {
            string[] input = System.IO.File.ReadAllLines("../../../Day 6/input.txt");

            //2D array to store the grid
            int rows = input.Length;
            int cols = input[0].Length;
            char[,] grid = new char[rows, cols];

            //Fill the grid
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    grid[i, j] = input[i][j];
                }
            }


            //Part 1
            int[,] directions = { { -1, 0 }, { 0, 1 }, { 1, 0 }, { 0, -1 } };
            
            int startX = 0; //starting point
            int startY = 0; //starting point
            int currentDir = 0;

            for(int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (grid[i, j] == '^')
                    {
                        startX = i;
                        startY = j;
                    }
                }
            }




            bool Simulate(char[,] testGrid)
            {
                HashSet<(int, int, int)> visitedStates = new HashSet<(int, int, int)>();

                // Initialize the guard's position and direction
                int x = startX;
                int y = startY;
                int currentDir = 0; // Always starts facing up (^)

                while (true)
                {

                    // Check if we've revisited the same state (position + direction)
                    if (!visitedStates.Add((x, y, currentDir)))
                    {
                        Console.WriteLine("Loop detected - VALID");
                        return true; // Loop detected
                    }

                    int nextX = x + directions[currentDir, 0];
                    int nextY = y + directions[currentDir, 1];

                    //break the loop if we leave the grid
                    if (nextX < 0 || nextY < 0 || nextX >= grid.GetLength(0) || nextY >= grid.GetLength(1))
                    {
                        Console.WriteLine("Out of bounds - NOT VALID");
                        return false;
                    }

                    if (grid[nextX, nextY] == '#')
                    {
                        currentDir = (currentDir + 1) % 4;

                    }
                    else
                    {
                        x = nextX;
                        y = nextY;
                    }

                }
            }

            // Brute force all possible positions for the new obstruction
            List<(int, int)> validPositions = new List<(int, int)>();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    // Check open spaces ('.') that are not the starting position
                    if (grid[i, j] == '.' && !(i == startX && j == startY))
                    {
                        // Place an obstruction and simulate
                        grid[i, j] = '#';
                        if (Simulate(grid))
                        {
                            validPositions.Add((i, j)); // Record valid positions
                            Console.WriteLine($"Valid Loop position: ({i}, {j})");
                            Console.WriteLine($"--------number of loops so far: {validPositions.Count}");
                        }
                        grid[i, j] = '.'; // Reset to original state
                    }
                }
            }

            // Output results
            Console.WriteLine($"Number of valid positions (part 2): {validPositions.Count}");




        }
    }
}
