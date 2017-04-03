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
        var lst = new List<int>(8);
        // game loop
        while (true)
        {
            lst.Clear();
            for (int i = 0; i < 8; i++)
            {
                int mountainH = int.Parse(Console.ReadLine()); 
                // represents the height of one mountain, from 9 to 0.
                lst.Add(mountainH);
            }

            // Write an action using Console.WriteLine()
            // To debug: Console.Error.WriteLine("Debug messages...");
            var maxIdx = lst.Select((value, index) => new{val = value, idx = index}).Aggregate((max, next) => max.val > next.val ? max : next).idx;
            Console.WriteLine(maxIdx); // The number of the mountain to fire on.
        }
    }
}