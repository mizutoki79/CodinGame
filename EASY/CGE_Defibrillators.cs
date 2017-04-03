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
    const double RadiusEarth = 6371;
    static void Main(string[] args)
    {
        string LON = Console.ReadLine().Replace(',', '.');
        string LAT = Console.ReadLine().Replace(',', '.');
        int N = int.Parse(Console.ReadLine()); 
        double Distance = double.MaxValue;
        string Name = "";
        for (int i = 0; i < N; i++)
        {
            string DEFIB = Console.ReadLine().Replace(',', '.');
            string[] DEFIBarray = DEFIB.Split(';');
            double tmp = CalcDistance(double.Parse(LON), double.Parse(LAT), double.Parse(DEFIBarray[4]), double.Parse(DEFIBarray[5]));
            if(Distance > tmp){
                Distance = tmp;
                Name = DEFIBarray[1];
            }
        }

        // Write an action using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");

        Console.WriteLine(Name);
    }

    static double CalcDistance(double lonA, double latA, double lonB, double latB){
        double x = (lonB - lonA) * Math.Cos((latA + latB) / 2);
        double y = (latB - latA);
        double d = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2)) * RadiusEarth;
        return d;
    }
}