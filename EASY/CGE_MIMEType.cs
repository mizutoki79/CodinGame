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
        int N = int.Parse(Console.ReadLine()); // Number of elements which make up the association table.
        int Q = int.Parse(Console.ReadLine()); // Number Q of file names to be analyzed.
        Dictionary<string, string> dict = new Dictionary<string, string>();
        for (int i = 0; i < N; i++)
        {
            string[] inputs = Console.ReadLine().Split(' ');
            string EXT = inputs[0]; // file extension
            string MT = inputs[1]; // MIME type.
            Console.Error.WriteLine("{0} {1}", EXT, MT);
            dict[EXT.ToLower()] = MT;
        }
        List<string> ans = new List<string>();
        for (int i = 0; i < Q; i++)
        {
            string FNAME = Console.ReadLine(); // One file name per line.
            Console.Error.WriteLine("FNAME {0}", FNAME);
            int pidx = FNAME.LastIndexOf(".") + 1;
            if(pidx != 0){
                string curext = FNAME.Substring(pidx, FNAME.Length - pidx).ToLower();
                Console.Error.WriteLine("EXT {0}", curext);
                if(dict.ContainsKey(curext)) ans.Add(dict[curext]);
                else ans.Add("UNKNOWN");
            }
            else ans.Add("UNKNOWN");
            Console.Error.WriteLine("MIME {0}", ans.Last());
        }

        // Write an action using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");


        // For each of the Q filenames, display on a line the corresponding MIME type. If there is no corresponding type, then display UNKNOWN.
        ans.ForEach(type => {Console.WriteLine(type);});
    }
}