using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode_2024.Day_9
{
    public class Puzzle9
    {
        public static void Solution(string[] args)
        {
            string input = File.ReadAllText("../../../Day 9/input.txt");
            Console.WriteLine(SolvePart2(input));
        }


        public static long SolvePart2(string input)
        {
            List<object> results = new List<object>();
            var data = input.Select(c => int.Parse(c.ToString())).ToArray();

            for (int i = 0; i < data.Length; i++)
            {
                if (i % 2 == 0) 
                {
                    results.AddRange(Enumerable.Repeat((long)(i / 2), data[i]).Cast<object>());
                }
                else 
                {
                    results.AddRange(Enumerable.Repeat<object>(".", data[i]));
                }
            }

            var fileResults = new List<object>(results);
            int lastIndex = fileResults.IndexOf(".");
            for (int i = fileResults.Count - 1; i > 1; i--)
            {
                if (fileResults[i] is string) continue;

                var number = (long)fileResults[i];
                int totalNumbers = 1;

                while (i - totalNumbers >= 0 && fileResults[i - totalNumbers] is long block && block == number)
                {
                    totalNumbers++;
                }

                int index = lastIndex;
                int countDots = 0;
                while (index < fileResults.Count)
                {
                    countDots = 0;
                    while (index + countDots < fileResults.Count && fileResults[index + countDots] is string)
                    {
                        countDots++;
                    }
                    if (countDots >= totalNumbers) break;
                    index = index + countDots + 1;
                }

                if (index > i || countDots < totalNumbers)
                {
                    i -= totalNumbers - 1;
                    continue;
                }

                for (int offset = 0; offset < totalNumbers; offset++)
                {
                    fileResults[i - offset] = ".";
                    fileResults[index + offset] = number;
                }
            }

            return fileResults
                .Select((value, index) => value is string ? 0 : (long)value * index)
                .Sum();
        }
    }
}
