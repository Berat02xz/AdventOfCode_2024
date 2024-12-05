using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode_2024.Day_4
{
    public class Puzzle4
    {
        public static void Solution(string[] args)
        {
            string input = File.ReadAllText("../../../Day 4/input.txt");
            string[] lines = input.Split("\n");

            int rows = lines.Length;
            int cols = lines[0].Length;

            char[,] grid = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {

                if (lines[i].Length < cols)
                {
                    lines[i] = lines[i].PadRight(cols, ' ');
                }

                for (int j = 0; j < cols; j++)
                {
                    grid[i, j] = lines[i][j];
                }
            }

            string word = "XMAS";
            string reverseWord = "SAMX";

            int count = 0;

            //Main for loop for XMAS
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (grid[row, col] == word[0])
                    {
                        Console.WriteLine("Found first letter at [" + row + "," + col + "] letter: " + grid[row, col]);
                        //Check all directions and up the count if true
                        if (checkHorizontal(grid, row, col, word))
                        {
                            count++;
                            Console.WriteLine("Horizontal Count");
                        }
                        if (checkVertical(grid, row, col, word))
                        {
                            count++;
                            Console.WriteLine("Vertical Count");
                        }
                        if (checkDiagonal(grid, row, col, word))
                        {
                            count++;
                            Console.WriteLine("Diagonal Count");
                        }
                        if (checkReverseDiagonal(grid, row, col, word))
                        {
                            count++;
                            Console.WriteLine("Reverse Diagonal Count");
                        }
                        if (checkHorizontal(grid, row, col - 3, reverseWord))
                        {
                            count++;
                            Console.WriteLine("Reverse Horizontal Count");
                        }
                        if (checkVertical(grid, row - 3, col, reverseWord))
                        {
                            count++;
                            Console.WriteLine("Reverse Vertical Count");
                        }
                        if (checkDiagonal(grid, row - 3, col - 3, reverseWord))
                        {
                            count++;
                            Console.WriteLine("Reverse Diagonal Count");
                        }
                        if (checkReverseDiagonal(grid, row + 3, col - 3, reverseWord))
                        {
                            count++;
                            Console.WriteLine("Reverse Reverse Diagonal Count");
                        }
                    }
                }
            }


            string MASs = "MAS";
            string reverseMAS = "SAM";
            int countMAS = 0;

            Console.WriteLine("X SHAPED MAS --------------------- PART 2:");
            //Main for loop for MAS
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (grid[row, col] == 'A')
                    {
                        int flag = 0;
                        Console.WriteLine("Found first letter at [" + row + "," + col + "] letter: " + grid[row, col]);
                        //Check all directions and up the count if true
                        if (checkDiagonal(grid, row - 1, col - 1, MASs))
                        {
                            flag++;
                            Console.WriteLine("Diagonal MAS");
                        }
                        if (checkReverseDiagonal(grid, row + 1, col - 1, MASs))
                        {
                            flag++;
                            Console.WriteLine("Reverse Diagonal MAS");
                        }
                        if (checkDiagonal(grid, row - 1, col - 1, reverseMAS))
                        {
                            flag++;
                            Console.WriteLine("Diagonal SAM");
                        }
                        if (checkReverseDiagonal(grid, row + 1, col - 1, reverseMAS))
                        {
                            flag++;
                            Console.WriteLine("Reverse Diagonal SAM");
                        }
                        if (flag == 2)
                        {
                            countMAS++;
                        }
                    }
                }
            }

            static bool checkHorizontal(char[,] grid, int row, int col, string word)
                    {
                    int wordLength = word.Length;
                    int cols = grid.GetLength(1);
                    if (cols - col < wordLength || col < 0)
                    {
                        return false;
                    }
                    for (int i = 0; i < wordLength; i++)
                    {
                        if (grid[row, col + i] != word[i])
                        {
                            return false;
                        }

                    }
                    //Print the whole word so i can debug if it was xmas

                    for (int i = 0; i < wordLength; i++)
                    {
                        Console.WriteLine("HORIZONTAL FOUND: " + grid[row, col + i]);
                    }

                    return true;
                }

                static bool checkVertical(char[,] grid, int row, int col, string word)
                {
                    int wordLength = word.Length;
                    int rows = grid.GetLength(0);
                    if (rows - row < wordLength || row < 0)
                    {
                        return false;
                    }
                    for (int i = 0; i < wordLength; i++)
                    {
                        if (grid[row + i, col] != word[i])
                        {
                            return false;
                        }

                    }

                    for (int i = 0; i < wordLength; i++)
                    {
                        Console.WriteLine("VERTICAL FOUND: " + grid[row + i, col]);
                    }

                    return true;
                }

                static bool checkDiagonal(char[,] grid, int row, int col, string word)
                {
                    int wordLength = word.Length;
                    int rows = grid.GetLength(0);
                    int cols = grid.GetLength(1);
                    if (rows - row < wordLength || cols - col < wordLength || col < 0 || row < 0)
                    {
                        return false;
                    }
                    for (int i = 0; i < wordLength; i++)
                    {
                        if (grid[row + i, col + i] != word[i])
                        {
                            return false;
                        }
                    }
                    for (int i = 0; i < wordLength; i++)
                    {
                        Console.WriteLine("DIAGONAL FOUND: " + grid[row + i, col + i]);
                    }
                    return true;
                }

                static bool checkReverseDiagonal(char[,] grid, int row, int col, string word)
                {
                    int wordLength = word.Length;
                    int rows = grid.GetLength(0);
                    int cols = grid.GetLength(1);
                    if (row < wordLength - 1 || col + wordLength > cols || col < 0 || row >= rows)
                    {
                        return false;
                    }
                    for (int i = 0; i < wordLength; i++)
                    {
                        if (grid[row - i, col + i] != word[i])
                        {
                            return false;
                        }
                    }
                    for (int i = 0; i < wordLength; i++)
                    {
                        Console.WriteLine("REVERSE DIAGONAL FOUND: " + grid[row - i, col + i]);
                    }
                    return true;
                }

                Console.WriteLine("XMAS Count: "+count);
                Console.WriteLine("X Shaped MAS Count:" + countMAS);

        }
        }
    }
