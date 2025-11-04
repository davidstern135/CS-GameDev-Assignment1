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
        string[] inputs = Console.ReadLine().Split(' ');

        // Track highest price and worst loss
        int maxPrice = int.Parse(inputs[0]);
        int maxLoss = 0;

        for (int i = 1; i < n; i++)
        {
            int currentPrice = int.Parse(inputs[i]);

            // Current loss if bought at highest price.
            int loss = currentPrice - maxPrice;

            // Keep worst loss.
            if (loss < maxLoss)
            {
                maxLoss = loss;
            }

            // Highest price seen.
            if (currentPrice > maxPrice)
            {
                maxPrice = currentPrice;
            }
        }

        // Write an answer using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");

        Console.WriteLine(maxLoss);
    }
}