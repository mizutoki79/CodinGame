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
        int R = int.Parse(Console.ReadLine());
        int L = int.Parse(Console.ReadLine());

        // Write an action using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");
        List<int> line = new List<int>();
        line.Add(R);
        string answer = string.Join(" ", NextLine(line, 1, L));
        Console.WriteLine(answer);
    }

    static List<int> NextLine(List<int> previous, int depth, int target)
    {
        if(depth++ >= target) return previous;
        List<int> result = new List<int>();
        int num = previous[0];
        int cnt = 1;
        for (int i = 1; i < previous.Count; i++)
        {
            if(num == previous[i]) cnt++;
            else
            {
                result.Add(cnt);
                result.Add(num);
                num = previous[i];
                cnt = 1;
            }
        }
        result.Add(cnt);
        result.Add(num);
        Console.Error.WriteLine(string.Join(" ", result));
        return NextLine(result, depth, target);
    }
}