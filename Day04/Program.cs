using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace ChristmasAdvent23
{
    class Day04
    {
        public static void Main()
        {
            var stopwatch = Stopwatch.StartNew();

            var data = File.ReadAllLines("input.txt")
                .Where(x => !String.IsNullOrEmpty(x) || !String.IsNullOrWhiteSpace(x))
                .ToArray();

            System.Console.WriteLine($"Pre-Compute: {stopwatch.Elapsed}");

            stopwatch = Stopwatch.StartNew();
            var part1 = getPart1(data);
            System.Console.WriteLine($"Part 1:{part1} With Time:{stopwatch.Elapsed}");

            stopwatch = Stopwatch.StartNew();
            var part2 = getPart2(data);
            System.Console.WriteLine($"Part 2:{part2} With Time:{stopwatch.Elapsed}");
        }

        public static long getPart1(string[] data)
        {
            var result = 0L;

            foreach (var line in data)
            {
                var each = line.Split(':')[1].Split('|', StringSplitOptions.TrimEntries);
                var pointValue = 0;
                var winEntry = new List<int>();
                foreach (var entry in each[0].Split(' ', StringSplitOptions.TrimEntries))
                {
                    if (int.TryParse(entry, out var value))
                    {
                        winEntry.Add(value);
                    }
                }

                foreach (var entry in each[1].Split(' ', StringSplitOptions.TrimEntries))
                {
                    if (int.TryParse(entry, out var value))
                    {
                        if (winEntry.Contains(value))
                        {
                            pointValue++;
                        }
                    }
                }

                result += DoubleOne(pointValue);
            }

            return result;
        }

        static int DoubleOne(int n)
        {
            if (n == 0)
                return 0;
            int result = 1;

            for (int i = 0; i < n - 1; i++)
            {
                result *= 2;
            }

            return result;
        }

        public static long getPart2(string[] data)
        {
            var result = 0L;
            var cardDict = new Dictionary<int, int>();

            var cardNumer = 0;

            foreach (var line in data)
            {
                var number = int.Parse(line.Split(':')[0].Split(' ', StringSplitOptions.TrimEntries).Last());
                cardDict.Add(number, 1);
                cardNumer++;
            }
            int cardcoutner = 1;

            foreach (var line in data)
            {
                var toDo = int.Parse(line.Split(':')[0].Split(' ').Last());
                var timesToRun = cardDict[toDo];

                var each = line.Split(':')[1].Split('|', StringSplitOptions.TrimEntries);
                var pointValue = 0;
                var winEntry = new List<int>();
                foreach (var entry in each[0].Split(' ', StringSplitOptions.TrimEntries))
                {
                    if (int.TryParse(entry, out var value))
                    {
                        winEntry.Add(value);
                    }
                }

                foreach (var entry in each[1].Split(' ', StringSplitOptions.TrimEntries))
                {
                    if (int.TryParse(entry, out var value))
                    {
                        if (winEntry.Contains(value))
                        {
                            pointValue++;
                        }
                    }
                }

                for (int i = cardcoutner + 1; i < cardcoutner + pointValue + 1; i++)
                {
                    if (cardDict.ContainsKey(i))
                    {
                        cardDict[i] += timesToRun;
                        cardNumer += timesToRun;
                    }
                }




                cardcoutner++;
            }
            result = cardNumer;

            return result;
        }
    }
}
