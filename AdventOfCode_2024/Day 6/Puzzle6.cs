using System;
using System.Collections.Generic;
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


            HashSet<(int,int)> visited = new HashSet<(int,int)>();

            //curr pos
            int x = startX;
            int y = startY;
            visited.Add((x, y));

            while (true)
            {
                int nextX = x + directions[currentDir, 0];
                int nextY = y + directions[currentDir, 1];

                //break the loop if we leave the grid
                if (nextX < 0 || nextY < 0 || nextX >= grid.GetLength(0) || nextY >= grid.GetLength(1))
                {
                    Console.WriteLine("Out of bounds - END");
                    break;
                }

                if (grid[nextX, nextY] == '#')
                {
                    currentDir = (currentDir + 1) % 4;
                    Console.WriteLine("TURN");
                    Console.WriteLine($"({x},{y})");
                }
                else
                {
                    x = nextX;
                    y = nextY;
                    visited.Add((x, y));
                    Console.WriteLine("MOVE");
                    Console.WriteLine($"({x},{y})");
                }

            }


            Console.WriteLine($"Distinct positions visited: {visited.Count}");
        }
    }
}
