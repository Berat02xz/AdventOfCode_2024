// This is the main class that calls the other classes to run the solutions for the problems
// At the end of the advent this class will be the one that will run all the solutions for the problems by letting you choose which day you want to run and compare times


using AdventOfCode_2024.Day_1;
using AdventOfCode_2024.Day_2;
using AdventOfCode_2024.Day_3;

namespace AdventOfCode_2024
{
    public class Start
    {
        public static void Main(string[] args)
        {
            // Puzzle1.Solution(args);
            //  Puzzle2.Solution(args);
            Puzzle3.Solution(args);
        }
    }
}
