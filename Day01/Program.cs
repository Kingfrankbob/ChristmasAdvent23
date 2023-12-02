using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace ChristmasAdvent23
{
    class Day01
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
                var numeroList = new List<int>();

                foreach (char c in line)
                {
                    if (int.TryParse(c.ToString(), out int i))
                    {
                        numeroList.Add(i);
                    }
                }
                var doneString = numeroList[0].ToString() + numeroList.Last().ToString();
                result += long.Parse(doneString);
            }

            return result;
        }

        public static Dictionary<string, int> allDigits = new Dictionary<string, int>
        {
            {"one", 1},
            {"two", 2},
            {"three", 3},
            {"four", 4},
            {"five", 5},
            {"six", 6},
            {"seven", 7},
            {"eight", 8},
            {"nine", 9},
            {"zero", 0},
            {"1", 1},
            {"2", 2},
            {"3", 3},
            {"4", 4},
            {"5", 5},
            {"6", 6},
            {"7", 7},
            {"8", 8},
            {"9", 9},
            {"0", 0}
        };

        public static long getPart2(string[] data)
        {
            var result = 0L;

            foreach (var line in data)
            {
                Dictionary<int, int> dict = new Dictionary<int, int>();

                foreach (var item in allDigits)
                {
                    if (line.Contains(item.Key))
                    {
                        dict.Add(line.IndexOf(item.Key), item.Value);
                        if (line.IndexOf(item.Key) != line.LastIndexOf(item.Key))
                            dict.Add(line.LastIndexOf(item.Key), item.Value);
                    }
                }
                var sortedDict = dict.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
                string doneString = sortedDict.First().Value.ToString() + sortedDict.Last().Value.ToString();
                result += long.Parse(doneString);
            }

            return result;
        }
    }
}
