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
    const int NUM_OF_ALP = 26;

    static void Main(string[] args)
    {
        int L = int.Parse(Console.ReadLine());
        int H = int.Parse(Console.ReadLine());
        string T = Console.ReadLine();
        Console.Error.WriteLine("T " + T);
        string[] aa = new string[H];
        for (int i = 0; i < H; i++)
        {
            string ROW = Console.ReadLine();
            aa[i] = ROW;
        }

        // Write an action using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");
        char[] textCh = T.ToCharArray();
        string[] answer = new string[H];
        for(int i = 0; i < textCh.Length; i++){
            for(int j = 0; j < H; j++){
                if('A' <= textCh[i] && textCh[i] <= 'Z'){
                    answer[j] += aa[j].Substring(((int)textCh[i] - (int)'A') * L, L);
                }
                else if('a' <= textCh[i] && textCh[i] <= 'z'){
                    answer[j] += aa[j].Substring(((int)textCh[i] - (int)'a') * L, L);
                }
                else{
                    answer[j] += aa[j].Substring(NUM_OF_ALP * L, L);
                }
            }
        }

        for(int i = 0; i < H; i++){
            Console.WriteLine(answer[i]);
        }
    }
}