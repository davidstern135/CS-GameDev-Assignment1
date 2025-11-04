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
class Player
{
    static void Main(string[] args)
    {
        string[] inputs;
        inputs = Console.ReadLine().Split(' ');
        int nbFloors = int.Parse(inputs[0]); // number of floors
        int width = int.Parse(inputs[1]); // width of the area
        int nbRounds = int.Parse(inputs[2]); // maximum number of rounds
        int exitFloor = int.Parse(inputs[3]); // floor on which the exit is found
        int exitPos = int.Parse(inputs[4]); // position of the exit on its floor
        int nbTotalClones = int.Parse(inputs[5]); // number of generated clones
        int nbAdditionalElevators = int.Parse(inputs[6]); // ignore (always zero)
        int nbElevators = int.Parse(inputs[7]); // number of elevators
        int[] elevators = new int[nbFloors];

        for (int i = 0; i < nbElevators; i++)
        {
            inputs = Console.ReadLine().Split(' ');
            int elevatorFloor = int.Parse(inputs[0]); // floor on which this elevator is found
            int elevatorPos = int.Parse(inputs[1]); // position of the elevator on its floor
            elevators[elevatorFloor] = elevatorPos;
        }
        int currentRound = 0;


        // game loop
        while (true)
        {
            inputs = Console.ReadLine().Split(' ');
            int cloneFloor = int.Parse(inputs[0]); // floor of the leading clone
            int clonePos = int.Parse(inputs[1]); // position of the leading clone on its floor
            string direction = inputs[2]; // direction of the leading clone: LEFT or RIGHT
            currentRound++;
            if (currentRound == nbRounds)
            {
                Console.WriteLine("Out of rounds.");
                break;
            }
            //no leading clone yet.
            if (direction == "NONE")
            {
                Console.WriteLine("WAIT");
                continue;
            }



            //finding the the right position on the current floor:
            int targetPos;
            if (cloneFloor == exitFloor)
            {
                //if the exit is on this floor
                targetPos = exitPos;
            }
            else
            {
                //if the exit is not on this floor, go to the elevator.
                targetPos = elevators[cloneFloor];
            }



            //checking if we are going in the right direction:
            bool blockTheClone = false;
            if (direction == "RIGHT" && clonePos > targetPos)
            {
                blockTheClone = true;
            }
            else if (direction == "LEFT" && clonePos < targetPos)
            {
                blockTheClone = true;
            }

            if (blockTheClone)
            {
                Console.WriteLine("BLOCK");
            }
            else
            {
                Console.WriteLine("WAIT");
            }




        }
    }
}