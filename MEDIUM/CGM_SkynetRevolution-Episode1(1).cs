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
class Player
{
    static void Main(string[] args)
    {
        string[] inputs;
        inputs = Console.ReadLine().Split(' ');
        int N = int.Parse(inputs[0]); // the total number of nodes in the level, including the gateways
        int L = int.Parse(inputs[1]); // the number of links
        int E = int.Parse(inputs[2]); // the number of exit gateways
        Skynet network = new Skynet(N);
        for (int i = 0; i < L; i++)
        {
            inputs = Console.ReadLine().Split(' ');
            int N1 = int.Parse(inputs[0]); // N1 and N2 defines a link between these nodes
            int N2 = int.Parse(inputs[1]);
            Skynet.CreateLink(N1, N2);
        }
        for (int i = 0; i < E; i++)
        {
            int EI = int.Parse(Console.ReadLine()); // the index of a gateway node
            Skynet.ToGateway(EI);
        }

        // game loop
        while (true)
        {
            int SI = int.Parse(Console.ReadLine()); // The index of the node on which the Skynet agent is positioned this turn
            //Skynet.CalculateDistance(network[SI], 0);
            var link = Skynet.CutLink(SI);
            Console.WriteLine("{0} {1}", link.Item1, link.Item2);
        }
    }
}


class Skynet
{   
    public class Node
    {
        internal int weight = int.MaxValue;
        internal List<Node> Links = new List<Node>();
        internal bool Gateway = false; 
        internal int indexValue;  //index

        public Node (int val)
        {
            this.indexValue = val;
        }

        public void ToGateway ()
        {
            this.Gateway = true;
        }

        internal bool IsGateway ()
        {
            return this.Gateway;
        }

        public override string ToString(){
            return string.Format("[node.{0} weight: {1}]", indexValue, weight);
        }
    }

    static Node[] network;

    public Skynet (int number)
    {
        network = new Node[number];
    }

    public Node this[int index]
    {
        get {return network[index];}
        set {network[index] = value;}
    }

    public static void CreateLink (int index1, int index2)
    {
        if(network[index1] == null) network[index1] = new Node(index1);
        if(network[index2] == null) network[index2] = new Node(index2);
        network[index1].Links.Add(network[index2]);
        network[index2].Links.Add(network[index1]);
    }

    static List<Tuple<Node, Node>> cutCandidateList = new List<Tuple<Node, Node>>();

    /*
    public static Tuple<int, int> CutLink ()
    {
        foreach (Tuple<Node, Node> pair in cutCandidateList)
        {
            Console.Error.WriteLine("{0} {1}", pair.Item1.ToString(), pair.Item2.ToString());
        }
        Console.Error.WriteLine("min distance: {0}", cutCandidateList.Min(elem2 => elem2.Item1.weight));
        Tuple<Node, Node> cutNodes = cutCandidateList
         .First(elem1 => elem1.Item1.weight == (cutCandidateList.Min(elem2 => elem2.Item1.weight)));
        CutLinkBetween(cutNodes.Item1, cutNodes.Item2);
        cutCandidateList.Clear();
        foreach (Node node in network) { node.weight = int.MaxValue; }
        return Tuple.Create(cutNodes.Item1.indexValue, cutNodes.Item2.indexValue);
    }
    */

    private static void CutLinkBetween (Node node1, Node node2)
    {
        node1.Links.Remove(node2);
        node2.Links.Remove(node1);
    }

    /*
    public static void CalculateDistance (Node node, int distance)
    {
        if(node.DistanceFromAgent > distance)
        {
            node.DistanceFromAgent = distance;
            foreach (Node nextNode in node.Links)
            {
                if(nextNode.IsGateway()) cutCandidateList.Add(Tuple.Create(node, nextNode));
                else CalculateDistance(nextNode, distance + 1);
            }
        }
    }
    */

    public static List<Node> gateways = new List<Node>();

    public static void ToGateway(int index)
    {
        network[index].ToGateway();
        gateways.Add(network[index]);
    }

    private static void CalculateWeight ()
    {
        foreach (Node gateway in gateways)
        {
            int thisWeight = 0;
            gateway.weight = thisWeight++;
            foreach (Node node in gateway.Links)
            {
                Calc(node, thisWeight++);
            }
        }
    }

    private static void Calc(Node node, int weight)
    {
        if(node.weight > weight)
        {
            node.weight = weight++;
            foreach (Node nextNode in node.Links)
            {
                Calc(nextNode, weight);
            }
        }
    }

    public static Tuple<int, int> CutLink (int agentIndex)
    {
        foreach (Node node in network) { node.weight = int.MaxValue; }
        CalculateWeight();
        foreach (Node node in network[agentIndex].Links) { Console.Error.WriteLine(node.ToString()); }
        int minWeight = network[agentIndex].Links.Min(elem => elem.weight);
        Console.Error.WriteLine("min weight = {0}", minWeight);
        int cutIndex = network[agentIndex].Links.First(elem => elem.weight.Equals(minWeight))
                                                .indexValue;
        CutLinkBetween(network[cutIndex], network[agentIndex]);
        return Tuple.Create(cutIndex, agentIndex);
    }
}