using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode_2024.Day_5
{
    public class Puzzle5
    {
        public static void Solution(string[] args)
        {
            string[] input = File.ReadAllLines("../../../Day 5/input.txt");
            
            var rules = new Dictionary<int, HashSet<int>>();
            int i = 0;

            //Populate HashMap with the rules from first part of input
            while (i<input.Length && !string.IsNullOrWhiteSpace(input[i]))
            {
                string[] parts = input[i].Split("|");
                int ruleNum = int.Parse(parts[0]);
                int ruleNum2 = int.Parse(parts[1]);
                if (rules.ContainsKey(ruleNum))
                {
                    rules[ruleNum].Add(ruleNum2);
                } else
                {
                    rules.Add(ruleNum, new HashSet<int> { ruleNum2 });
                }
                i++;
            }

            //Populate Array with the numbers from second part of input
            var updates = new List<int[]>();
            for(int j = i + 1; j < input.Length; j++)
            {
                string[] parts = input[j].Split(",");
                int[] nums = new int[parts.Length];
                for (int k = 0; k < parts.Length; k++)
                {
                    nums[k] = int.Parse(parts[k]);
                }
                updates.Add(nums);
            }

            //Main loop to check if the rules are valid
            int sumOfMiddlePages = 0;
            int sumOfInvalidMiddlePages = 0;

            foreach (var update in updates)
            {
               if(!IsByValue(update,rules))
                {
                    int[] sorted = (int[])FixedArray(update, rules);

                    sumOfInvalidMiddlePages += sorted[sorted.Length / 2];

                    Console.WriteLine("Invalid - Middle Page: " + update[update.Length / 2]);
                    Console.WriteLine("Sum of Invalid/Fixed Middle Pages: " + sumOfInvalidMiddlePages);
                }
                else
                {
                    sumOfMiddlePages += update[update.Length / 2];
                    Console.WriteLine("Valid - Middle Page: " + update[update.Length / 2]);
                    Console.WriteLine("Sum of Middle Pages: " + sumOfMiddlePages);
                }
            }

            Console.WriteLine("Sum of Middle Pages: " + sumOfMiddlePages);
        }

        private static object FixedArray(int[] update, Dictionary<int, HashSet<int>> rules)
        {

            for (int i = 0; i < update.Length; i++)
            {
                for (int j = i + 1; j < update.Length; j++)
                {
                    int current = update[i];
                    int next = update[j];

                    if (rules.ContainsKey(next) && rules[next].Contains(current))
                    {
                        update[i] = next;
                        update[j] = current;
                    }
                }
            }
            return update;

        }

        private static bool IsByValue(int[] update, Dictionary<int, HashSet<int>> rules)
        {
            for(int i = 0; i < update.Length; i++)
            {
                int current = update[i];

                if(rules.ContainsKey(current))
                {
                    HashSet<int> next = rules[current];

                    for (int j = i - 1; j >= 0; j--)
                    {
                        if (next.Contains(update[j]))
                        {
                            Console.WriteLine("Invalid Array, Line - " + current + " -> " + update[j]);
                            return false;
                        }
                    }
                }
            }
            Console.WriteLine("Valid Array - " + string.Join(",", update));
            return true;
        }
    }
}
