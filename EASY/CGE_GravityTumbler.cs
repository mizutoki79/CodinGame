using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
class Solution
{
    static void Main(string[] args)
    {
        string[] inputs = Console.ReadLine().Split(' ');
        int width = int.Parse(inputs[0]);
        int height = int.Parse(inputs[1]);
        int count = int.Parse(Console.ReadLine());
        var rastermap = new char[height][];
        for (int i = 0; i < height; i++)
        {
            rastermap[i] = Console.ReadLine().ToCharArray();
        }

        // Write an action using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");
        for (int i = 0; i < count; i++) rastermap = Tumble(rastermap);
        for (int i = 0; i < rastermap.GetLength(0); i++) Console.WriteLine(string.Join("", rastermap[i]));
    }

    static int CountChar(string str, char ch)
    {
        return str.Length - str.Replace(ch.ToString(), "").Length;
    }

    static char[][] Tumble(char[][] map)
    {
        var h = map[0].Length;
        var w = map.Length;
        var transposed = Enumerable.Range(0, h).Select(i => new char[w]).ToArray();
        for (int i = 0; i < w; i++)
        {
            for (int j = 0; j < h; j++)
            {
                transposed[j][i] = map[i][j];
            }
        }
        Array.Sort(transposed, heavier);
        return transposed;
    }

    static int heavier(char[] arr1, char[] arr2)
    {
        return arr1.Where(elem => elem == '#').Count() - arr2.Where(elem => elem == '#').Count();
    }
}