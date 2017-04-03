using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 * ---
 * Hint: You can use the debug stream to print initialTX and initialTY, if Thor seems not follow your orders.
 **/
class Player
{
    static void Main(string[] args)
    {
        string[] inputs = Console.ReadLine().Split(' ');
        int lightX = int.Parse(inputs[0]); // the X position of the light of power
        int lightY = int.Parse(inputs[1]); // the Y position of the light of power
        int initialTX = int.Parse(inputs[2]); // Thor's starting X position
        int initialTY = int.Parse(inputs[3]); // Thor's starting Y position

        int currentX = initialTX;
        int currentY = initialTY;
        string direction;

        // game loop
        while (true)
        {
            int remainingTurns = int.Parse(Console.ReadLine()); // The remaining amount of turns Thor can move. Do not remove this line.

            // Write an action using Console.WriteLine()
            // To debug: Console.Error.WriteLine("Debug messages...");
            if(lightY > currentY) {
                direction = "S";
                currentY++;
            }
            else if(lightY < currentY){
                direction = "N";
                currentY--;
            }
            else direction = "";

            if(lightX > currentX){
                direction += "E";
                currentX++;
            }
            else if(lightX < currentX){
                direction += "W";
                currentX--;
            }
            // A single line providing the move to be made: N NE E SE S SW W or NW
            Console.WriteLine(direction);
        }
    }
}