namespace AdventOfCode_2024.Day_2
{
    public  class Puzzle2
    {
        public static void Solution(string[] args)
        {

            StreamReader reader = new StreamReader("../../../Day 2/input.txt");
            string[] lines = reader.ReadToEnd().Split("\n");

            int totalSafe = 0;
            int totalUnsafe = 0;

            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                int[] numbers = line.Split(' ').Select(int.Parse).ToArray();

                if (is_safe_report(numbers))
                {
                    totalSafe++;
                    Console.WriteLine("Safe: " + line);
                }
                else
                {
                    totalUnsafe++;
                    Console.WriteLine("Unsafe: " + line);
                }

            }
            Console.WriteLine($"Total Safe: {totalSafe}");
            Console.WriteLine($"Total Unsafe: {totalUnsafe}");
        }



        public static bool is_safe_report(int[] numbers)
        {
            if (numbers.Length <= 2)
                return true; // For Single-element or 2-element array

            int initialDifference = Math.Sign(numbers[1] - numbers[0]); // Determine the initial diff

            int maximumAllowed = 1; // Maximum allowed difference
            
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                int difference = numbers[i + 1] - numbers[i];

                // Check for consistency in sign and validate the difference range
                if (Math.Sign(difference) != initialDifference || Math.Abs(difference) < 1 || Math.Abs(difference) > 3)
                {
                    maximumAllowed--;
                    if (maximumAllowed < 0)
                    {
                        return false; // Inconsistent or invalid difference
                    }
                }
            }

            return true; // Passed all checks
        }



    }
}
