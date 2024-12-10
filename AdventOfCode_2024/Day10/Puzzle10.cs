using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode_2024.Day10
{
    public class Puzzle10
    {
        public static void Solution(string[] args)
        {
            string input = File.ReadAllText("../../../Day10/input.txt").Trim();
            string[] lines = input.Split("\n");
            int rows = lines.Length;
            int columns = lines[0].Length;
            int totalRating = 0;

            int[,] map = new int[rows, columns];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    map[i, j] = lines[i][j] - '0'; //char to int
                }
            }

            //(right, down, left, up)
            int[,] directions = { { 0, 1 }, { 1, 0 }, { 0, -1 }, { -1, 0 } };
            int totalScore = 0;

            int BFS(int startX, int startY)
            {
                var visited = new bool[rows, columns];
                var queue = new Queue<(int x, int y, int height)>();
                var pathsToNineCount = 0; 

                queue.Enqueue((startX, startY, 0)); 
                visited[startX, startY] = true;

                while (queue.Count > 0)
                {
                    var (x, y, currentHeight) = queue.Dequeue();
                    string path = $"{x},{y},{currentHeight}"; 

                    for (int i = 0; i < 4; i++) //loop through the 4 directions
                    {
                        int nx = x + directions[i, 0];
                        int ny = y + directions[i, 1];

                        //outside the grid check
                        if (nx >= 0 && nx < rows && ny >= 0 && ny < columns && !visited[nx, ny])
                        {
                            if (map[nx, ny] == currentHeight + 1)
                            {
                                visited[nx, ny] = true;
                                queue.Enqueue((nx, ny, currentHeight + 1));

                                //part2
                                string newPath = $"{nx},{ny},{currentHeight + 1}";

                                //if bingo 9
                                if (map[nx, ny] == 9)
                                {
                                    pathsToNineCount++; 
                                }
                            }
                        }
                    }
                }

                return pathsToNineCount;
            }

            //MAIN
            for(int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (map[i, j] == 0)
                    {
                        totalRating += BFS(i, j); // Calculate the distinct trails from the trailhead
                    }
                }
            }

            Console.WriteLine("Total Rating: " + totalRating);

        }
    }
}
