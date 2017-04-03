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
        string MESSAGE = Console.ReadLine();

        // Write an action using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");
        Console.Error.WriteLine(MESSAGE);
        Console.Error.WriteLine((int)MESSAGE[0]);
        string answer = MESSAGE
                    .Select(ch => Convert.ToString((int)ch, 2).PadLeft(7, '0'))
                    .Aggregate((working, next) => working + next);
        Console.Error.WriteLine(answer);
        answer = ToUnaryMsg(answer);
        Console.WriteLine(answer);
    }

    static string ToUnaryMsg(string ascii){
        string unary = "";
        for(int i = 0; i < ascii.Length; i++){
            if(i > 0 && ascii[i] == ascii[i - 1]) unary += "0";
            else{
                if(i != 0) unary += " ";
                unary += ascii[i] == '0' ? "00 0" : "0 0";
            }
        }
        return unary;
    }
}