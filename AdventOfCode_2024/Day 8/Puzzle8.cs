using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace AdventOfCode_2024.Day_8
{
    public class Puzzle8
    {
        public static void Solution(string[] args)
        {
            string[] input = File.ReadAllLines("../../../Day 8/input.txt");

            //store into 2D array
            int rows = input.Length;
            int cols = input[0].Length;

            char[,] map = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    map[i, j] = input[i][j];
                }
            }

            Dictionary<char, List<(int, int)>> antenna = new Dictionary<char, List<(int, int)>>();

            //find anything that is not a '.' and put in dictionary
            for(int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (map[i, j] != '.')
                    {
                        if (!antenna.ContainsKey(map[i, j]))
                        {
                            antenna[map[i, j]] = new List<(int, int)>();
                        }
                        antenna[map[i, j]].Add((i, j));
                    }
                }
            }

            HashSet<(int, int)> uniqueAntinodes = new HashSet<(int, int)>();

            //biizzii
            foreach (var entry in antenna)
            {
                var frequency = entry.Key;
                var coordinates = entry.Value;

                for(int i = 0; i < coordinates.Count; i++)
                {
                    for(int j=i+ 1; j < coordinates.Count; j++)
                    {
                        var (x1, y1) = coordinates[i];
                        var (x2, y2) = coordinates[j];
                        //direction between antenas
                        int dx = x2 - x1;
                        int dy = y2 - y1;

                        //keep adding antinodes and checking for their bounds
                        for (int k = 1; k <= Math.Max(rows, cols); k++)
                        {
                            //direction 1
                            AddAntinodes(rows, cols, uniqueAntinodes, x1, y1, x2, y2, -k * dx, -k * dy);

                            //direction 2
                            AddAntinodes(rows, cols, uniqueAntinodes, x1, y1, x2, y2, k * dx, k * dy);
                        }
                    }
                }
            }

            Console.WriteLine("Updated Map:");
            foreach (var (x, y) in uniqueAntinodes)
            {
                map[x, y] = '#';
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(map[i, j]);
                }
                Console.WriteLine();
            }

            Console.WriteLine($"Total unique antinode locations: {uniqueAntinodes.Count}");

        }

        //refactor from part 1
        private static void AddAntinodes(int rows, int cols, HashSet<(int, int)> uniqueAntinodes, int x1, int y1, int x2, int y2, int dx, int dy)
        {
            int antinode1X = x1 - dx;
            int antinode1Y = y1 - dy;
            int antinode2X = x2 + dx;
            int antinode2Y = y2 + dy;

            if (IsWithinBounds(antinode1X, antinode1Y, rows, cols))
            {
                uniqueAntinodes.Add((antinode1X, antinode1Y));
            }
            if (IsWithinBounds(antinode2X, antinode2Y, rows, cols))
            {
                uniqueAntinodes.Add((antinode2X, antinode2Y));
            }
        }

        private static bool IsWithinBounds(int antinode1X, int antinode1Y, int rows, int cols)
        {
        return antinode1X >= 0 && antinode1X < rows && antinode1Y >= 0 && antinode1Y < cols;
        }
    }
}
