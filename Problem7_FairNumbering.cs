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
        for (int i = 0; i < N; i++)
        {
            string[] inputs = Console.ReadLine().Split(' ');
            int st = int.Parse(inputs[0]);
            int ed = int.Parse(inputs[1]);

            // Binary search for the split point
            int left = st;
            int right = ed - 1;
            int result = st;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                long aliceDigits = CountDigitsRange(st, mid);
                long bobDigits = CountDigitsRange(mid + 1, ed);

                if (aliceDigits <= bobDigits)
                {
                    result = mid;
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            Console.WriteLine(result);
        }
    }

    // Count total digits in range [start, end]
    static long CountDigitsRange(int start, int end)
    {
        if (start > end) return 0;
        return CountDigitsUpTo(end) - CountDigitsUpTo(start - 1);
    }

    // Count total digits needed to write 1, 2, 3, ..., n
    static long CountDigitsUpTo(int n)
    {
        if (n <= 0) return 0;

        long total = 0;
        long power = 1;  // 10^(d-1) where d is current digit count
        int d = 1;       // Current digit count

        while (power <= n)
        {
            // Calculate upper bound for d-digit numbers
            long upperBound = power * 10 - 1;
            if (upperBound > n)
            {
                upperBound = n;
            }

            // Count of d-digit numbers in range [power, upperBound]
            long count = upperBound - power + 1;
            total += count * d;

            // Move to next digit length
            power *= 10;
            d++;
        }

        return total;
    }
}