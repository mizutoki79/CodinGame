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
        string[] lines = new string[height];
        for (int i = 0; i < height; i++)
        {
            lines[i] = Console.ReadLine(); // width characters, each either 0 or .
        }
        int next = 0;
        int x1;
        int y1;
        int hi = 0;
        do{
            x1 = lines[hi].IndexOf('0', next);
            if(x1 != -1) y1 = hi;
            else{
                hi++;
                continue;
            }
            int x2 = x1 + 1 < width ? lines[hi].IndexOf('0', x1 + 1) : -1;
            int y2 = x2 != -1 ? hi : -1;
            int i = 1;
            while(hi + i < height && lines[hi + i][x1] == '.'){
                i++;
            }
            int y3 = hi + i < height ? hi + i : -1;
            int x3 = y3 != -1 ? x1 : -1;
            Console.WriteLine("{0} {1} {2} {3} {4} {5}", x1, y1, x2, y2, x3, y3);
            if(x2 != -1){
                next = x2;
            }
            else{
                hi++;
                next = 0;
            }
        }while(hi < height);
        
        
        // Write an action using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");


        // Three coordinates: a node, its right neighbor, its bottom neighbor
    }
}