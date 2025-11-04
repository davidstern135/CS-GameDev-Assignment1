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
        string[] arr = new string[N];
        for (int i = 0; i < N; i++)
        {
            string W = Console.ReadLine();
            arr[i] = W;
        }
        string LETTERS = Console.ReadLine();
        int highScore = 0;
        int index = 0;

        // Find word with highest score.
        for (int i = 0; i < N; i++)
        {
            int score = checkAndCalculate(arr[i], LETTERS);
            if (score > highScore)
            {
                highScore = score;
                index = i;
            }
        }

        Console.WriteLine(arr[index]);
    }

    static int checkAndCalculate(string s, string letters)
    {
        // Convert to List to track used letters.
        List<char> availableLetters = letters.ToList();
        int sum = 0;

        for (int i = 0; i < s.Length; i++)
        {
            char currentChar = s[i];

            // Check if letter is available.
            if (availableLetters.Contains(currentChar))
            {
                sum += calculateLetter(currentChar);
                availableLetters.Remove(currentChar); // Remove used letter.
            }
            else
            {
                return 0; // Can't form word, missing letter.
            }
        }
        return sum;
    }

    static int calculateLetter(char a)
    {
        // Scrabble letter values.
        char[] onePoint = { 'e', 'a', 'i', 'o', 'n', 'r', 't', 'l', 's', 'u' };
        char[] twoPoints = { 'd', 'g' };
        char[] threePoints = { 'b', 'c', 'm', 'p' };
        char[] fourPoints = { 'f', 'h', 'v', 'w', 'y' };
        char fivePoints = 'k';
        char[] eightPoints = { 'j', 'x' };
        char[] tenPoints = { 'q', 'z' };

        if (onePoint.Contains(a))
        {
            return 1;
        }
        else if (twoPoints.Contains(a))
        {
            return 2;
        }
        else if (threePoints.Contains(a))
        {
            return 3;
        }
        else if (fourPoints.Contains(a))
        {
            return 4;
        }
        else if (fivePoints == a)
        {
            return 5;
        }
        else if (eightPoints.Contains(a))
        {
            return 8;
        }
        else if (tenPoints.Contains(a))
        {
            return 10;
        }
        else
        {
            return 0;
        }
    }
}