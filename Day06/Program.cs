using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day06
{
    class Program
    {
        private static string input = File.ReadAllText(@"..\..\..\data\day06.txt");
        static void Main(string[] args)
        {
            BothParts();
            Console.ReadLine();
        }

        private static void BothParts()
        {
            // States dictionary
            // Key   = comma separated list of values 
            // Value = the number of cycles that first produced the key
            Dictionary<string, int> states = new Dictionary<string, int>();

            // Parse input to List<int>
            List<int> initialState = new List<int>();
            foreach (var item in input.Split('\t'))
            {
                int.TryParse(item, out int num);
                initialState.Add(num);
            }

            // Store initial state in dictionary
            states.Add(string.Join(",", initialState), 1);

            bool keepGoing = true;
            int cycles = 0, loopSize = 0;
            List<int> lastState = initialState.ToList();

            while (keepGoing)
            {
                cycles++;
                List<int> newState = lastState.ToList();

                // Find largest number
                int max = newState.Max(n => n);
                int index = newState.IndexOf(max);
                int toRedis = max;

                // Set the index with largest number to 0
                newState[index] = 0;

                // Then redistribute 
                do
                {
                    index++;
                    if (index > newState.Count - 1) index -= newState.Count;
                    newState[index]++;
                    toRedis--;
                } while (toRedis > 0);

                // Create comma separated string to store in dictionary
                string chain = string.Join(",", newState);

                //Console.WriteLine(chain);

                // Check if the new state exists in the dictionary
                if (states.ContainsKey(chain))
                {
                    // Find the size of the infinite loop (number of cycles)
                    // as the current number of cycles less the number of cycles
                    // when the chain was first added to the states dictionary 
                    loopSize = cycles - states[chain];
                    keepGoing = false;
                    break;
                }

                // Otherwise, add new state to dictionary and continue loop
                states.Add(chain, cycles);
                lastState = newState.ToList();
            }

            Console.WriteLine($"Part 1: {cycles} cycles");

            Console.WriteLine($"Part 2: Loop size: {loopSize} cycles");
        }
    }
}
