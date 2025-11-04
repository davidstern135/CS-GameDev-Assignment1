using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
 * Don't let the machines win. You are humanity's last hope...
 **/
class Player
{
    static void Main(string[] args)
    {
        int width = int.Parse(Console.ReadLine()); // the number of cells on the X axis
        int height = int.Parse(Console.ReadLine()); // the number of cells on the Y axis

        // Store the grid
        char[,] grid = new char[width, height];

        // Read input grid
        for (int y = 0; y < height; y++)
        {
            string line = Console.ReadLine(); // width characters, each either 0 or .
            for (int x = 0; x < width; x++)
            {
                grid[x, y] = line[x];
            }
        }

        // Write an action using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");

        // Process each cell
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                // Only process nodes
                if (grid[x, y] == '0')
                {
                    string output = x + " " + y + " ";

                    // Find right neighbor
                    bool foundRight = false;
                    for (int rightX = x + 1; rightX < width; rightX++)
                    {
                        if (grid[rightX, y] == '0')
                        {
                            output += rightX + " " + y + " ";
                            foundRight = true;
                            break;
                        }
                    }
                    if (!foundRight)
                    {
                        output += "-1 -1 ";
                    }

                    // Find bottom neighbor
                    bool foundBottom = false;
                    for (int bottomY = y + 1; bottomY < height; bottomY++)
                    {
                        if (grid[x, bottomY] == '0')
                        {
                            output += x + " " + bottomY;
                            foundBottom = true;
                            break;
                        }
                    }
                    if (!foundBottom)
                    {
                        output += "-1 -1";
                    }

                    Console.WriteLine(output);
                }
            }
        }

        // Three coordinates: a node, its right neighbor, its bottom neighbor
    }
}