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
        int W = int.Parse(inputs[0]); // width of the building.
        int H = int.Parse(inputs[1]); // height of the building.
        int N = int.Parse(Console.ReadLine()); // maximum number of turns before game over.
        inputs = Console.ReadLine().Split(' ');
        int X0 = int.Parse(inputs[0]);
        int Y0 = int.Parse(inputs[1]);
        int x = X0;
        int y = Y0;
        int minY = 0;
        int maxY = H;
        int minX = 0;
        int maxX = W;

        // game loop
        while (true)
        {
            string bombDir = Console.ReadLine(); // the direction of the bombs from batman's current location (U, UR, R, DR, D, DL, L or UL)

            // Write an action using Console.WriteLine()
            // To debug: Console.Error.WriteLine("Debug messages...");
            if(bombDir.Contains("U")) maxY = --y;
            else if(bombDir.Contains("D")) minY = ++y;
            if(bombDir.Contains("L")) maxX = --x;
            else if(bombDir.Contains("R")) minX = ++x;
            x = (maxX + minX) / 2;
            y = (maxY + minY) / 2;

            // the location of the next window Batman should jump to.
            Console.WriteLine("{0} {1}", x, y);
        }
    }
}