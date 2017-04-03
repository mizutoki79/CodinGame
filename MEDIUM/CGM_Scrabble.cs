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
        #region initialize point table
        var pointLetters = new Char[][]
        {
            "eaionrtlsu".ToCharArray(), //1
            "dg".ToCharArray(),         //2
            "bcmp".ToCharArray(),       //3
            "fhvwy".ToCharArray(),      //4
            "k".ToCharArray(),          //5
            new char[0], new char[0],   //6-7
            "jx".ToCharArray(),         //8
            new char[0],                //9
            "qz".ToCharArray()          //10
        };
        var pointTable = new Dictionary<char, int>();
        for (int i = 0; i < 10; i++)
        {
            foreach (var letter in pointLetters[i])
            {
                pointTable.Add(letter, i + 1);
            }
        }
        #endregion


        int N = int.Parse(Console.ReadLine());
        string[] words = new string[N];
        for (int i = 0; i < N; i++)
        {
            words[i] = Console.ReadLine();
            Console.Error.WriteLine(i + " " + words[i]);
        }
        string LETTERS = Console.ReadLine();
        Console.Error.WriteLine("LETTERS: {0}", LETTERS);
        int[] score = new int[N];
        int maxScore = 0;
        int maxIndex = 0;
        for (int i = 0; i < N; i++)
        {
            string invalidLetter = words[i];
            foreach (char letter in LETTERS)
            {
                int idx = invalidLetter.IndexOf(letter);
                if(idx != -1) invalidLetter = invalidLetter.Remove(idx, 1);
            }
            if(invalidLetter.Length > 0) continue;
            
            for (int j = 0; j < words[i].Length; j++)
            {
                score[i] += pointTable[words[i][j]];
                if(maxScore < score[i])
                {
                    Console.Error.WriteLine("max = {0}, score[{1}] = {2}", maxScore, i, score[i]);
                    maxScore = score[i];
                    maxIndex = i;
                }
            }
            Console.Error.WriteLine("score[{0}] = {1}", maxIndex, score[maxIndex]);
        }
        //int index = score.Select((elem, idx) => new {E = elem, I = idx})
        //                 .First(elem => elem.E == score.Max()).I;
        Console.WriteLine(words[maxIndex]);
    }
}