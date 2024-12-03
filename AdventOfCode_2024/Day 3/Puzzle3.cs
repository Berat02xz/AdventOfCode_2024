using System.Text.RegularExpressions;

namespace AdventOfCode_2024.Day_3
{
    public class Puzzle3
    {
        public static void Solution(string[] args)
        {

            //StreamRead the input
            string[] lines = File.ReadAllLines("../../../Day 3/input.txt");

            string pattern = @"mul\((\d+),(\d+)\)";
            Regex regex = new Regex(pattern);


            bool doFlag = true;
            int total = 0;

            foreach (var line in lines)
            {
                foreach (Match match in Regex.Matches(line, @"do\(\)|don't\(\)|mul\((\d+),(\d+)\)"))
                {
                    if(match.Value == "do()")
                    {
                        doFlag = true;
                        Console.WriteLine($"'do()' found: Flag set to {doFlag}");

                    }
                    else if (match.Value == "don't()")
                    {
                        doFlag = false;
                        Console.WriteLine($"'don't()' found: Flag set to {doFlag}");
                    }

                    if (doFlag && regex.IsMatch(match.Value) )
                    {
                        int num1 = int.Parse(match.Groups[1].Value);
                        int num2 = int.Parse(match.Groups[2].Value);
                        total += num1 * num2;
                        Console.WriteLine(match.Value + " = " + num1 * num2);
                    }

                }
            }
            Console.WriteLine("Total: " + total);
        }
    }
}
