using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace ChristmasAdvent21
{
    class DayXX
    {
        public static List<char> Symbols = new List<char>
        {
                '!',
                '@',
                '#',
                '$',
                '%',
                 '^',
    '&',
    '*',
    '(',
    ')',
    '-',
    '_',
    '=',
    '+',
    '[',
    ']',
    '{',
    '}',
    ';',
    ':',
    '\'',
    '"',
    ',',
    '<',
    '.',
    '>',
    '/',
    '?',
    '\\',
    '|',
    '`',
    '~',
    ' ',
        };
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

            for (int i = 0; i < data.Length; i++)
            {
                string line = data[i];
                // System.Console.WriteLine($"Line is {line}");
                var currentNumber = "";
                for (int digit = 0; digit < line.Length; digit++)
                {
                    // System.Console.WriteLine(line[i]);

                    if (int.TryParse(line[digit].ToString(), out int value))
                    {
                        currentNumber += value.ToString();
                        // System.Console.WriteLine(value + "Has been added");
                    }
                    else if (!char.IsDigit(line[digit]) &&
                     !string.IsNullOrWhiteSpace(currentNumber) &&
                     !string.IsNullOrEmpty(currentNumber) &&
                     IsAdjacentToSymbol(int.Parse(currentNumber), i, data)
                     )
                    {
                        // System.Console.WriteLine("Cleared");
                        result += long.Parse(currentNumber);
                        currentNumber = "";
                    }
                    else if (!char.IsDigit(line[digit]) &&
                     !string.IsNullOrWhiteSpace(currentNumber) &&
                     !string.IsNullOrEmpty(currentNumber) &&
                     !IsAdjacentToSymbol(int.Parse(currentNumber), i, data)
                     )
                    {
                        // System.Console.WriteLine("Cleared");
                        currentNumber = "";
                    }
                }
            }

            return result;
        }

        public static bool IsAdjacentToSymbol(int number, int line, string[] dataSet)
        {
            var previousLine = line == 0 ? null : dataSet[line - 1];
            var currentLine = dataSet[line];
            var nextLine = line == dataSet.Length - 1 ? null : dataSet[line + 1];

            var numberIndex = currentLine.IndexOf(number.ToString());

            if (checkLine(currentLine, previousLine, number, numberIndex, true) || checkLine(currentLine, nextLine, number, numberIndex, false))
            {
                return true;
            }
            else
                return false;

        }

        public static bool checkLine(string currentLine, string? compareLine, int number, int indexer, bool top)
        {
            if (compareLine == null)
                return false;

            // System.Console.WriteLine(top ? "Top" : "Bottom");

            bool canPass = false;
            for (int i = indexer - (indexer == 0 ? 0 : 1);
             i < indexer + number.ToString().Length + (indexer + number.ToString().Length == currentLine.Length ? 0 : 1);
              i++)
            {
                if (i < 0)
                    continue;
                // System.Console.WriteLine($"{number} can Pass {i}");
                if (compareLine[i] != '.' &&
                !char.IsDigit(compareLine[i]))
                {
                    // System.Console.WriteLine($"{number} can Pass bove or low");
                    canPass = true;
                }
            }

            // System.Console.WriteLine($"{number} has index -of1 {indexer - 1} and index of {indexer}");

            if (indexer != 0 && currentLine[indexer - 1] != '.')
            {
                // System.Console.WriteLine($"{number} can Pass -1");
                canPass = true;
            }

            if (indexer + number.ToString().Length != currentLine.Length &&
             currentLine[indexer + number.ToString().Length] != '.')
            {
                // System.Console.WriteLine($"{number} can Pass +1");
                canPass = true;
            }


            return canPass;
        }

        public static long getPart2(string[] data)
        {
            var result = 0L;

            return result;
        }
    }
}

