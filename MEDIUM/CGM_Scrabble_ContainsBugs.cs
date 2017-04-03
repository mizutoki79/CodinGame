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
        HashSet<char>[] hs = new HashSet<char>[N];
        for (int i = 0; i < N; i++)
        {
            words[i] = Console.ReadLine();
            Console.Error.WriteLine(i + " " + words[i]);
            hs[i] = new HashSet<char>(words[i].ToCharArray());
        }
        string LETTERS = Console.ReadLine();
        Console.Error.WriteLine("LETTERS: {0}", LETTERS);
        var common = new char[N][];
        int[] score = new int[N];
        for (int i = 0; i < N; i++)
        {
            common[i] = Array.FindAll(LETTERS.ToCharArray(), hs[i].Contains);
            score[i] = 0;
            if(common[i].Length < words[i].Length) continue;
            Console.Error.Write("{0}: common letter [", i);
            foreach (var letter in common[i])
            {
                Console.Error.Write("{0} ", letter);
                score[i] += pointTable[letter];
            }
            Console.Error.WriteLine("] : {0}", score[i]);
        }
        int index = score.Select((elem, idx) => new {E = elem, I = idx})
                         .First(elem => elem.E == score.Max()).I;
        Console.WriteLine(words[index]);
    }
}

/*
This program contains bugs.
if "INPUT" is 
    1
    a
    aaaaaaa
, the word's score is 7.
duplicate charactor is important information.
I shouldn't have used HashSet.
*/