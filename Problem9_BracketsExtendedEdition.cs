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
        string[] expressions = new string[N];

        for (int i = 0; i < N; i++)
        {
            expressions[i] = Console.ReadLine();
        }

        for (int i = 0; i < N; i++)
        {
            // Check if expression can be valid
            bool result = CanBeValid(expressions[i]);

            if (result)
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("false");
            }
        }
    }

    static bool CanBeValid(string expression)
    {
        // Extract only brackets
        List<char> brackets = new List<char>();
        for (int i = 0; i < expression.Length; i++)
        {
            char c = expression[i];
            if (c == '(' || c == ')' || c == '[' || c == ']' ||
                c == '{' || c == '}' || c == '<' || c == '>')
            {
                brackets.Add(c);
            }
        }

        // Must have even number
        if (brackets.Count % 2 != 0)
        {
            return false;
        }

        // Use stack to match types
        Stack<char> stack = new Stack<char>();

        for (int i = 0; i < brackets.Count; i++)
        {
            char bracket = brackets[i];
            char type = GetType(bracket);

            if (stack.Count > 0)
            {
                char topType = GetType(stack.Peek());
                if (topType == type)
                {
                    // Same type - can pair
                    stack.Pop();
                }
                else
                {
                    // Different type - push
                    stack.Push(bracket);
                }
            }
            else
            {
                // Empty stack - push
                stack.Push(bracket);
            }
        }

        // Valid if empty
        if (stack.Count == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    static char GetType(char bracket)
    {
        if (bracket == '(' || bracket == ')')
        {
            return 'p';
        }
        else if (bracket == '[' || bracket == ']')
        {
            return 's';
        }
        else if (bracket == '{' || bracket == '}')
        {
            return 'c';
        }
        else if (bracket == '<' || bracket == '>')
        {
            return 'a';
        }
        else
        {
            return ' ';
        }
    }
}