using System;
using System.Collections.Generic;
using System.Linq;

namespace Day03
{
    class Program
    {
        private static int input = 265149;

        static void Main(string[] args)
        {
            Part1();
            Part2();
            Console.ReadLine();
        }

        private static void Part1()
        {
            int currentIncrement = 1;
            List<SpiralItem> spiral = new List<SpiralItem> { new SpiralItem(1, currentIncrement, SpiralItem.SpiralDirection.Down, 0, 0) };
            bool keepGoing = true;

            // Loop until the number added to the spiral is >= the input value
            while (keepGoing)
            {
                // Increase the increment value by 1 every other spiral addition
                // Corners are reached in the increment pattern: 1,1,2,2,3,3,4,4,..
                if (spiral.Count > 1 && spiral.Count % 2 == 0) currentIncrement++;

                // Create the next value in the spiral and add it to spiral
                SpiralItem newSpiralItem =
                    new SpiralItem(spiral.Last().Num, currentIncrement, spiral.Last().Direction, spiral.Last().X, spiral.Last().Y);
                spiral.Add(newSpiralItem);

                //Console.WriteLine($"{newSpiralItem.Num} = ({newSpiralItem.X},{newSpiralItem.Y}), {newSpiralItem.Direction}");

                // Check if the new corner spiral number has exceeded the input value
                if (newSpiralItem.Num >= input)
                {
                    keepGoing = false;
                    Console.WriteLine($"{newSpiralItem.Num} = Corner: ({newSpiralItem.X},{newSpiralItem.Y})");
                    Console.WriteLine($"Direction: {newSpiralItem.Direction}");

                    // Initialize Final X and Y co-ords for the input value
                    int finalX = newSpiralItem.X;
                    int finalY = newSpiralItem.Y;

                    // The difference between the corner value and the input value
                    int diff = newSpiralItem.Num - input;

                    // Depending on the direction just travelled around the spiral
                    // Go backwards around the spiral the number of steps equal to the diff value
                    switch (newSpiralItem.Direction)
                    {
                        case SpiralItem.SpiralDirection.Right:
                            finalX = newSpiralItem.X - diff;
                            break;
                        case SpiralItem.SpiralDirection.Up:
                            finalY = newSpiralItem.Y - diff;
                            break;
                        case SpiralItem.SpiralDirection.Left:
                            finalX = newSpiralItem.X + diff;
                            break;
                        case SpiralItem.SpiralDirection.Down:
                            finalY = newSpiralItem.Y + diff;
                            break;
                    }

                    // Number of steps to (0,0) is the sum of the positive X and Y co-ord values
                    int steps = Math.Abs(finalX) + Math.Abs(finalY);

                    Console.WriteLine($"{input} Position: ({finalX},{finalY})");
                    Console.WriteLine($"Steps: {steps}");
                }
            }
        }

        private static void Part2()
        {
            List<SpecialSpiralItem> spiralItems = new List<SpecialSpiralItem>()
            {
                new SpecialSpiralItem { Num = 1, X = 0, Y = 0, Direction = SpiralItem.SpiralDirection.Down }
            };

            bool keepGoing = true;
            int sideLength = 0;
            int sidesCompleted = 0;

            Console.WriteLine($"{spiralItems.Last().Num} \t ({spiralItems.Last().X},{spiralItems.Last().Y})  \t{spiralItems.Last().Direction} \t {sideLength}");

            while (keepGoing)
            {
                if (sidesCompleted % 2 == 0) sideLength++;
                for (int i = 1; i <= sideLength; i++)
                {
                    // Create the new spiral item
                    SpecialSpiralItem newSpiralItem =
                        new SpecialSpiralItem(spiralItems.Last().Direction, i, spiralItems.Last().X, spiralItems.Last().Y);

                    // Set the spiral item value as the Sum of the adjacent spiral items
                    int lowX = newSpiralItem.X - 1,
                        lowY = newSpiralItem.Y - 1,
                        highX = newSpiralItem.X + 1,
                        highY = newSpiralItem.Y + 1;

                    foreach (var item in spiralItems)
                    {
                        if ((lowX <= item.X && item.X <= highX) && (lowY <= item.Y && item.Y <= highY)) newSpiralItem.Num += item.Num;
                    }

                    // Add to spiral
                    spiralItems.Add(newSpiralItem);
                    Console.WriteLine($"{newSpiralItem.Num} \t ({newSpiralItem.X},{newSpiralItem.Y})  \t{newSpiralItem.Direction}  \t {i}/{sideLength}");

                    // Check if the value of the last item added to the Spiral is larger than the input value
                    if (newSpiralItem.Num > input)
                    {
                        keepGoing = false;
                        break;
                    }
                }
                sidesCompleted++;
            }
        }
    }
}
