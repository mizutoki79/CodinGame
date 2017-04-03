using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;

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
        int W = int.Parse(inputs[0]); // number of columns.
        int H = int.Parse(inputs[1]); // number of rows.
        room[,] grid = new room[W, H];
        for (int i = 0; i < H; i++)
        {
            string[] LINE = Console.ReadLine().Split(' '); // represents a line in the grid and contains W integers. Each integer represents one room of a given type.
            for (int j = 0; j < W; j++)
            {
                grid[j, i] = new room(int.Parse(LINE[j]));
            }
        }
        int EX = int.Parse(Console.ReadLine()); // the coordinate along the X axis of the exit (not useful for this first mission, but must be read).

        // game loop
        while (true)
        {
            inputs = Console.ReadLine().Split(' ');
            int XI = int.Parse(inputs[0]);
            int YI = int.Parse(inputs[1]);
            string POS = inputs[2];

            // Write an action using Console.WriteLine()
            // To debug: Console.Error.WriteLine("Debug messages...");
            Point next = Point.Add(new Point(XI, YI), (Size)grid[XI, YI].NextFrom(POS));

            // One line containing the X Y coordinates of the room in which you believe Indy will be on the next turn.
            Console.WriteLine("{0} {1}", next.X, next.Y);
        }
    }
}

class room
{
    List<Tuple<string, string>> route;
    public room(int n)
    {
        route = new List<Tuple<string, string>>();
        switch (n)
        {
            case 1:
                route.Add(Tuple.Create("TOP", "DOWN"));
                route.Add(Tuple.Create("RIGHT", "DOWN"));
                route.Add(Tuple.Create("LEFT", "DOWN"));
                break;
            case 2:
            case 6:
                route.Add(Tuple.Create("LEFT", "RIGHT"));
                route.Add(Tuple.Create("RIGHT", "LEFT"));
                break;
            case 3:
                route.Add(Tuple.Create("TOP", "DOWN"));
                break;
            case 4:
                route.Add(Tuple.Create("TOP", "LEFT"));
                route.Add(Tuple.Create("RIGHT", "DOWN"));
                break;
            case 5:
                route.Add(Tuple.Create("TOP", "RIGHT"));
                route.Add(Tuple.Create("LEFT", "DOWN"));
                break;
            case 7:
                route.Add(Tuple.Create("TOP", "DOWN"));
                route.Add(Tuple.Create("RIGHT", "DOWN"));
                break;
            case 8:
                route.Add(Tuple.Create("RIGHT", "DOWN"));
                route.Add(Tuple.Create("LEFT", "DOWN"));
                break;
            case 9:
                route.Add(Tuple.Create("TOP", "DOWN"));
                route.Add(Tuple.Create("LEFT", "DOWN"));
                break;
            case 10:
                route.Add(Tuple.Create("TOP", "LEFT"));
                break;
            case 11:
                route.Add(Tuple.Create("TOP", "RIGHT"));
                break;
            case 12:
                route.Add(Tuple.Create("RIGHT", "DOWN"));
                break;
            case 13:
                route.Add(Tuple.Create("LEFT", "DOWN"));
                break;
            default:
                route.Add(Tuple.Create("NONE", "NONE"));
                break;
        }
    }

    internal Point NextFrom(string entrance)
    {
        string exit = route.First(elem => elem.Item1 == entrance).Item2;
        switch (exit)
        {
            case "LEFT":
                return new Point(-1, 0);
            case "RIGHT":
                return new Point(1, 0);
            case "DOWN":
                return new Point(0, 1);
            default:
                return new Point(0, 0);
        }
    }
}

