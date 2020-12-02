using System;
using System.IO;
using System.Collections.Generic;

namespace Day04
{
    class Program
    {
        private static string[] input = File.ReadAllLines(@"..\..\..\data\day04.txt");

        static void Main(string[] args)
        {
            Part1();
            Part2();
            Console.ReadLine();
        }

        private static void Part1()
        {
            int validCount = 0;

            // Iterate through every line of the input
            foreach (var line in input)
            {
                // Create phrases array by splitting the line on space character
                string[] phrases = line.Split();

                // Create dictionary to hold each phrase
                Dictionary<string, int> phrasesDict = new Dictionary<string, int>();
                bool valid = true;

                // Iterate through each phrase
                foreach (var phrase in phrases)
                {
                    // Check if the phrase is in the dictionary, if it is break the loop as invalid
                    if (phrasesDict.ContainsKey(phrase))
                    {
                        valid = false;
                        break;
                    }

                    // Otherwise, add the phrase to the dictionary and continue loop
                    phrasesDict.Add(phrase, 1);
                }

                if (valid) validCount++;
            }

            Console.WriteLine($"Part 1: {validCount} valid passphrases");
        }

        private static void Part2()
        {
            int validCount = 0;

            foreach (var line in input)
            {
                string[] phrases = line.Split();
                Dictionary<string, int> phrasesDict = new Dictionary<string, int>();
                bool valid = true;

                foreach (var phrase in phrases)
                {
                    string sortedPhrase = SortString(phrase);
                    
                    if (phrasesDict.ContainsKey(sortedPhrase))
                    {
                        valid = false;
                        break;
                    }

                    phrasesDict.Add(sortedPhrase, 1);
                }

                if (valid) validCount++;
            }

            Console.WriteLine($"Part 2: {validCount} valid passphrases");
        }

        private static string SortString(string input)
        {
            char[] chars = input.ToCharArray();
            Array.Sort(chars);
            return new string(chars);
        }
    }
}
