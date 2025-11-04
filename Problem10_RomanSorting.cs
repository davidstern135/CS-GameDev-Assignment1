using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
class Solution
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int[] numbers = new int[n];

        for (int i = 0; i < n; i++)
        {
            numbers[i] = int.Parse(Console.ReadLine());
        }

        // Convert to Roman numerals and sort alphabetically
        List<string> romanNumerals = new List<string>();
        for (int i = 0; i < n; i++)
        {
            string roman = ToRoman(numbers[i]);
            romanNumerals.Add(roman);
        }

        // Create pairs of (number, roman) and sort by roman
        List<Pair> pairs = new List<Pair>();
        for (int i = 0; i < n; i++)
        {
            Pair p = new Pair();
            p.number = numbers[i];
            p.roman = romanNumerals[i];
            pairs.Add(p);
        }

        // Sort by roman numeral alphabetically
        pairs.Sort((a, b) => string.Compare(a.roman, b.roman));

        // Output sorted numbers
        for (int i = 0; i < n; i++)
        {
            Console.Write(pairs[i].number);
            if (i < n - 1)
            {
                Console.Write(" ");
            }
        }
        Console.WriteLine();
    }

    // Convert integer to Roman numeral
    static string ToRoman(int num)
    {
        int[] values = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
        string[] numerals = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };

        string result = "";
        for (int i = 0; i < values.Length; i++)
        {
            while (num >= values[i])
            {
                result += numerals[i];
                num -= values[i];
            }
        }
        return result;
    }
}

// Helper class to store number-roman pairs
class Pair
{
    public int number;
    public string roman;
}