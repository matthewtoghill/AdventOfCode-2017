using System;
using System.IO;

namespace Day01
{
    class Program
    {
        private static string input = File.ReadAllText(@"..\..\..\data\day01.txt");
        //private static string input = "12131415";
        static void Main(string[] args)
        {
            Part1();
            Part2();
            Console.ReadLine();
        }

        private static void Part1()
        {
            int sum = 0;

            for (int i = 0; i < input.Length; i++)
            {
                int.TryParse(input[i].ToString(), out int currentNum);
                int nextPos = i < input.Length - 1 ? i + 1 : 0;
                int.TryParse(input[nextPos].ToString(), out int nextNum);
                if (currentNum == nextNum) sum += currentNum;
            }

            Console.WriteLine($"Part 1: {sum}");
        }

        private static void Part2()
        {
            int sum = 0;
            int steps = input.Length / 2;

            for (int i = 0; i < input.Length; i++)
            {
                int.TryParse(input[i].ToString(), out int currentNum);

                int nextPos = i + steps;
                if (nextPos > input.Length - 1) nextPos -= input.Length;

                int.TryParse(input[nextPos].ToString(), out int nextNum);

                if (currentNum == nextNum) sum += currentNum;
            }

            Console.WriteLine($"Part 2: {sum}");
        }
    }
}
