using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode_2024.Day11
{
    public class Puzzle11
    {
        public static void Solution(string[] args)
        {
            string input = File.ReadAllText("../../../Day11/input.txt");

            var initialStones = input.Trim().Split().Select(long.Parse).ToList();

            LinkedList<long> stones = new LinkedList<long>(initialStones);

            int blinks = 75;
            int NumberOfStones = stones.Count;

            for (int blink = 0; blink < blinks; blink++)
            {
                var currentNode = stones.First;

                while (currentNode != null)
                {
                    var nextNode = currentNode.Next;

                    if (currentNode.Value == 0)
                    {
                        currentNode.Value = 1;
                    }
                    else if (currentNode.Value > 0 && currentNode.Value.ToString().Length % 2 == 0)
                    {
                        string vString = currentNode.Value.ToString();
                        int half = vString.Length / 2;
                        long firstHalf = int.Parse(vString.Substring(0, half));
                        long secondHalf = int.Parse(vString.Substring(half, vString.Length - half));

                        stones.AddBefore(currentNode, firstHalf);
                        stones.AddAfter(currentNode, secondHalf);
                        stones.Remove(currentNode);
                        NumberOfStones+=2;
                        Console.WriteLine($"Number of stones after {blink} blinks: {NumberOfStones}");
                    }
                    else
                    {
                        int mul = 2024;
                        currentNode.Value *= mul;
                    }
                    currentNode = nextNode;
                }
            }
            Console.WriteLine($"Number of stones after {blinks} blinks: {NumberOfStones}");
        }
    }
}
