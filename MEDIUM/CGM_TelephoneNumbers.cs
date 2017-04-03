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
        int N = int.Parse(Console.ReadLine());
        var numberStorage = new List<Tree>();
        for (int i = 0; i < N; i++)
        {
            string telephone = Console.ReadLine();

            bool done = false;
            for (int j = 0; j < numberStorage.Count; j++)
            {
                if(numberStorage[j].RootValue == telephone[0])
                {
                    numberStorage[j].Add(telephone);
                    done = true;
                }
            }
            if(!done)
            {
                Tree tmpTree = new Tree(telephone[0]);
                tmpTree.Add(telephone);
                numberStorage.Add(tmpTree);
                done = true;
            }
        }
        int cnt = 0;
        foreach (var item in numberStorage)
        {
            cnt += item.Count;
        }
        Console.WriteLine(cnt);
    }
}

class Tree
{
    internal class Node
    {
        public char Value {get; internal set;}
        internal Node parent;
        internal List<Node> next = new List<Node>();

        internal Node(char val, Node parent)
        {
            this.Value = val;
            this.parent = parent;
        }

        internal void Add(Node next)
        {
            if(!this.next.Contains(next))this.next.Add(next);
        }

        public override bool Equals (object obj)
        {
            if (obj == null || this.GetType() != obj.GetType())
            {
                return false;
            }
            Node tmp = (Node)obj;
            return this.Value == tmp.Value;
        }
        public override int GetHashCode()
        {
        return this.Value;
        }
    }

    private Node root;
    public char RootValue
    {
        get {return this.root.Value;}
    }
    public int Count {get; private set;}

    public Tree(char val)
    {
        this.root = new Node(val, null);
        this.Count++;
    }

    public void Add(string phoneNumber)
    {
        Node node = this.root;
        for (int i = 1; i < phoneNumber.Length; i++)
        {
            int idx = node.next.IndexOf(new Node(phoneNumber[i], null));
            if(idx != -1) node = node.next[idx];
            else
            {
                Node newNode = new Node(phoneNumber[i], node);
                node.next.Add(newNode);
                node = newNode;
                this.Count++;
            }
        }
    }
}