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
        int R = int.Parse(Console.ReadLine());
        int L = int.Parse(Console.ReadLine());

        // Start with initial sequence
        List<int> sequence = new List<int> { R };

        // Generate L-1 iterations
        for (int i = 1; i < L; i++)
        {
            sequence = NextLevel(sequence);
        }

        // Output result
        Console.WriteLine(string.Join(" ", sequence));
    }

    static List<int> NextLevel(List<int> current)
    {
        List<int> next = new List<int>();

        int i = 0;
        while (i < current.Count)
        {
            int value = current[i];
            int count = 1;

            // Count consecutive same values
            while (i + count < current.Count && current[i + count] == value)
            {
                count++;
            }

            // Add count then value
            next.Add(count);
            next.Add(value);

            i += count;
        }

        return next;
    }
}