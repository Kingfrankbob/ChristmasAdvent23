using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace ChristmasAdvent23
{
    class Day03
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

            return result;
        }

        public static long getPart2(string[] data)
        {
            var result = 0L;

            return result;
        }
    }
}
