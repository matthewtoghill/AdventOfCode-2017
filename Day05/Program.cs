using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Day05
{
    class Program
    {
        private static string[] input = File.ReadAllLines(@"..\..\..\data\day05.txt");

        static void Main(string[] args)
        {
            Part1();
            Part2();
            Console.ReadLine();
        }

        private static void Part1()
        {
            List<int> jumpList = input.Select(x => int.Parse(x)).ToList();

            int i = 0, steps = 0;

            do
            {
                int currentVal = jumpList[i];
                jumpList[i] = currentVal + 1;
                i += currentVal;
                steps++;
            } while (i >= 0 && i < jumpList.Count - 1);

            Console.WriteLine($"Part 1: {steps} steps");
        }

        // Same as Part 1 except that currentVals 3 or higher now reduce the value rather than increase it before moving on
        private static void Part2()
        {
            List<int> jumpList = input.Select(x => int.Parse(x)).ToList();
            
            int i = 0, steps = 0;

            do
            {
                int currentVal = jumpList[i];
                jumpList[i] = currentVal >= 3 ? currentVal - 1 : currentVal + 1;
                i += currentVal;
                steps++;
            } while (i >= 0 && i < jumpList.Count - 1) ;

            Console.WriteLine($"Part 2: {steps} steps");
        }
    }
}
