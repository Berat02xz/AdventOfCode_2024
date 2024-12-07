using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode_2024.Day_7
{
    public class Puzzle7
    {
        public static void Solution(string[] args)
        {
            string[] input = System.IO.File.ReadAllLines("../../../Day 7/input.txt");

            long totalCalibrationResult = 0;

            foreach (var line in input)
            {
                var parts = line.Split(": ");
                long targetValue = long.Parse(parts[0]); // int displays error, so changed to long
                var numbers = Array.ConvertAll(parts[1].Split(' '), long.Parse);

                if (CanMatchTarget(numbers, targetValue))
                {
                    totalCalibrationResult += targetValue;
                }
            }
            Console.WriteLine($"Total calibration result: {totalCalibrationResult}");

            //if target value can be get from combination of numbers
            static bool CanMatchTarget(long[] numbers, long targetValue)
            {
                int operatorCount = numbers.Length - 1;
                int maxCombinations = (int)Math.Pow(3, operatorCount); //total number of calculations needed (brute forcing)

                for (int i = 0; i < maxCombinations; i++)
                {
                    var operators = GenerateOperators(i, operatorCount);
                    
                    if (EvaluateExpression(numbers, operators) == targetValue)
                    {
                        return true;
                    }
                }

                return false;
            }

            //char array with the operators that loop
            static char[] GenerateOperators(int combinationIndex, int operatorCount)
            {
                char[] operators = new char[operatorCount];
                for (int i = 0; i < operatorCount; i++)
                {
                    int op = combinationIndex % 3;
                    combinationIndex /= 3;

                    if (op == 0)
                        operators[i] = '+';
                    else if (op == 1)
                        operators[i] = '*';
                    else
                        operators[i] = '|'; 
                }
                return operators;
            }


            static long EvaluateExpression(long[] numbers, char[] operators)
            {
                long result = numbers[0];

                for (int i = 0; i < operators.Length; i++)
                {


                    if (operators[i] == '+')
                    {
                        result += numbers[i + 1];
                    }
                    else if (operators[i] == '*')
                    {
                        result *= numbers[i + 1];
                    }
                    else if (operators[i] == '|') 
                    {
                        result = long.Parse($"{result}{numbers[i + 1]}");
                    }
                }

                return result;
            }


        }
    }
    }
