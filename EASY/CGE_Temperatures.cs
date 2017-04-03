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
        int n = int.Parse(Console.ReadLine()); // the number of temperatures to analyse
        string[] temps = Console.ReadLine().Split(' '); // the n temperatures expressed as integers ranging from -273 to 5526
        int[] tempsArray = new int[n];
        for(int i = 0; i < n; i++){
            tempsArray[i] = int.Parse(temps[i]);
            Console.Error.Write(tempsArray[i] + " ");
        }
        Console.Error.WriteLine();
        // Write an action using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");
        int result = 0;
        if(tempsArray.Length == 0) result = 0;
        else result = int.MaxValue;

        foreach(int val in tempsArray){
            if(Math.Abs(val) < Math.Abs(result)) result = val;
            else if(Math.Abs(val) == Math.Abs(result)) result = val > 0 ? val : result;
        }
        Console.WriteLine(result);
    }
}