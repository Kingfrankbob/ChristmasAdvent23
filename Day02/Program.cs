using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace ChristmasAdvent23
{
    class Day02
    {
        public static int MaxRed = 12, MaxGreen = 13, MaxBlue = 14;
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
                var gameInfo = line.Split(':');
                var gameId = int.Parse(gameInfo[0].Split(' ')[1]);
                var allRounds = gameInfo[1].Split(';', StringSplitOptions.TrimEntries);
                bool breakk = true;

                foreach (var round in allRounds)
                {
                    var colors = round.Split(',', StringSplitOptions.TrimEntries);

                    foreach (var color in colors)
                    {
                        var colorInfo = color.Split(' ');
                        var colorCount = int.Parse(colorInfo[0]);
                        var colorName = colorInfo[1];

                        switch (colorName)
                        {
                            case "red" when colorCount > MaxRed:
                            case "green" when colorCount > MaxGreen:
                            case "blue" when colorCount > MaxBlue:
                                breakk = false;
                                break;
                        }

                        if (!breakk)
                        {
                            break;
                        }
                    }
                }

                if (breakk)
                {
                    result += gameId;
                }
            }

            return result;
        }

        public static long getPart2(string[] data)
        {
            var result = 0L;

            foreach (var line in data)
            {
                var gameInfo = line.Split(':');
                var gameId = int.Parse(gameInfo[0].Split(' ')[1]);
                var allRounds = gameInfo[1].Split(';', StringSplitOptions.TrimEntries);

                int bigRed = 0, bigGreen = 0, bigBlue = 0;

                foreach (var round in allRounds)
                {
                    var colors = round.Split(',', StringSplitOptions.TrimEntries);

                    foreach (var color in colors)
                    {
                        var colorInfo = color.Split(' ');
                        var colorCount = int.Parse(colorInfo[0]);
                        var colorName = colorInfo[1];

                        switch (colorName)
                        {
                            case "red":
                                if (colorCount > bigRed)
                                {
                                    bigRed = colorCount;
                                }
                                break;
                            case "green":
                                if (colorCount > bigGreen)
                                {
                                    bigGreen = colorCount;
                                }
                                break;
                            case "blue":
                                if (colorCount > bigBlue)
                                {
                                    bigBlue = colorCount;
                                }
                                break;
                        }
                    }
                }
                result += bigRed * bigGreen * bigBlue;
            }

            return result;
        }
    }
}
