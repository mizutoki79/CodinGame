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
        int n = int.Parse(Console.ReadLine());
        string[] inputs = Console.ReadLine().Split(' ');
        int[] stock = new int[n];
        for (int i = 0; i < n; i++)
        {
            int v = int.Parse(inputs[i]);
            stock[i] = v;
        }

        // Write an action using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");
        int t0 = stock[0];
        int t1 = t0;
        int loss = 0;
        for (int i = 1; i < n; i++)
        {
            if(stock[i] > t0)
            {
                t0 = stock[i];
                t1 = t0;
            }
            else if(t1 > stock[i])
            {
                t1 = stock[i];
                if(loss > t1 - t0) loss = t1 - t0;
            }
        }
        Console.WriteLine(loss);
    }
}