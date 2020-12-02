using System;
using System.IO;
using System.Collections.Generic;

namespace Day02
{
    class Program
    {
        private static string[] input = File.ReadAllLines(@"..\..\..\data\day02.txt");
        static void Main(string[] args)
        {
            Part1();
            Part2();
            Console.ReadLine();
        }

        private static void Part1()
        {
            int checkSum = 0;
            foreach (var line in input)
            {
                string[] vals = line.Split('\t');
                int min = int.MaxValue, max = 0;
                foreach (var val in vals)
                {
                    int.TryParse(val, out int thisNum);
                    if (thisNum < min) min = thisNum;
                    if (thisNum > max) max = thisNum;
                }

                Console.WriteLine($"Min: {min} \t Max: {max} \t Diff: {max - min}");
                checkSum += (max - min);
            }

            Console.WriteLine($"Part 1: {checkSum}");
        }

        private static void Part2()
        {
            int checkSum = 0;
            foreach (var line in input)
            {
                string[] vals = line.Split('\t');
                List<int> sortedInput = new List<int>();

                // Parse each value and add to List
                foreach (var val in vals)
                {
                    int.TryParse(val, out int thisNum);
                    sortedInput.Add(thisNum);
                }

                // Sort then Reverse the list of parsed values to get High to Low vals
                sortedInput.Sort();
                sortedInput.Reverse();

                bool keepGoing = true;
                while (keepGoing)
                {
                    int numerator = sortedInput[0];
                    for (int i = 1; i < sortedInput.Count; i++)
                    {
                        int divisor = sortedInput[i];
                        if (numerator % divisor == 0)
                        {
                            int result = numerator / divisor;
                            checkSum += result;
                            Console.WriteLine($"Numerator: {numerator} \t Divisor: {divisor} \t Result: {result}");
                            keepGoing = false;
                        }
                    }
                    sortedInput.RemoveAt(0);
                }
            }
            Console.WriteLine($"Part 2: {checkSum}");
        }
    }
}
