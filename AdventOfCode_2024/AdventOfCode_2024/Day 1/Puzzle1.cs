using System;
using System.Text.RegularExpressions;

namespace AdventOfCode_2024.Day_1
{
    public class Puzzle1
    {
        public static void Main(string[] args)
        {
            //Read Lines from input
            using StreamReader reader = new StreamReader("./Day 1/input.txt");
            string[] lines = reader.ReadToEnd().Split("\n");

            //two arrays to store the numbers
            List<int> arr1 = new List<int>();
            List<int> arr2 = new List<int>();

            //split the tab in every line and put to two arrays
            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                string[] numbers = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                arr1.Add(int.Parse(numbers[0]));
                arr2.Add(int.Parse(numbers[1]));
            }

            //Sort the arrays by ascdending order
            arr1.Sort();
            arr2.Sort();

            int hole = 0;
            //Find the hole between two arrays
            for(int start = 0; start < arr1.Count; start++)
            {
                hole += Math.Abs(arr1[start] - arr2[start]);
            }
            Console.WriteLine($"total distance between the lists: {hole}");


        }

    }
}
