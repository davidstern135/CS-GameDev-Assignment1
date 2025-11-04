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
        int N = int.Parse(Console.ReadLine());
        List<int> XCoords = new List<int>();
        List<int> YCoords = new List<int>();
        for (int i = 0; i < N; i++)
        {
            string[] inputs = Console.ReadLine().Split(' ');
            int X = int.Parse(inputs[0]);
            int Y = int.Parse(inputs[1]);
            XCoords.Add(X);
            YCoords.Add(Y);
        }

        //finding the length of the main cable from east to west.
        long mainCable = XCoords.Max() - XCoords.Min();

        //sort the Y coordinates to find the median.
        YCoords.Sort();
        int median = YCoords[N / 2];
        long totalLength = mainCable;
        for (int i = 0; i < N; i++)
        {
            totalLength += Math.Abs(median - YCoords[i]);
        }

        // Write an answer using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");

        Console.WriteLine(totalLength);
    }
}