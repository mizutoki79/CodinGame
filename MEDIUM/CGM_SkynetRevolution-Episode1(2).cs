using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;

class Player
{
    static void Main (string[] args)
    {
        string[] inputs = Console.ReadLine().Split(' ');
        //Console.Error.WriteLine(string.Join(" ", inputs));
        int N = int.Parse(inputs[0]); // the total number of nodes in the level, including the gateways
        int L = int.Parse(inputs[1]); // the number of links
        int E = int.Parse(inputs[2]); // the number of exit gateways
        Skynet nodes = new Skynet(N);
        for (int i = 0; i < L; i++)
        {
            inputs = Console.ReadLine().Split(' ');
            int N1 = int.Parse(inputs[0]); // N1 and N2 defines a link between these nodes
            int N2 = int.Parse(inputs[1]);
            nodes.CreateLink(nodes[N1], nodes[N2]);
        }
        for (int i = 0; i < E; i++)
        {
            int EI = int.Parse(Console.ReadLine()); // the index of a gateway node
            nodes.ToGateway(nodes[EI]);
        }
        while (true)
        {
            int SI = int.Parse(Console.ReadLine()); // The index of the node on which the Skynet agent is positioned this turn
            Tuple<Skynet.Node, Skynet.Node> link = nodes.SeverLink(SI);
            Console.WriteLine("{0} {1}", link.Item1.Val, link.Item2.Val);
        }
    }
}

class Skynet
{
    Node[] network;
    List<Node> gatewayList = new List<Node>();
    public Node this[int i]
    {
        get {return network[i];}
        set {network[i] = value;}
    }

    public Skynet (int num)
    {
        network = new Node[num];
        for (int i = 0; i < num; i++) { network[i] = new Node(i); }
    }

    public void ToGateway(Node node)
    {
        node.IsGateway = true;
        gatewayList.Add(node);
    }

    public void CreateLink (Node node1, Node node2)
    {
        node1.Links.Add(node2);
        node2.Links.Add(node1);
    }

    public Tuple<Node, Node> SeverLink (int SI)
    {
        CalculateDistanceFromAgent(SI);
        CalculateDistanceFromGateway();
        foreach (Node node in network) node.DistanceFromGateway.Sort();
        foreach (Node node in network) { Console.Error.WriteLine(node.ToString()); }
        foreach (Node nextNode in network[SI].Links) 
        {
            if(nextNode.IsGateway)
            {
                CutLinkBetween(nextNode, network[SI]);
                return Tuple.Create(nextNode, network[SI]);
            } 
        }

        var candidate = network.OrderBy(node => node.Links.Count)
                            .ThenBy(node => node.DistanceFromAgent);
        var candidate2 = candidate.Where(node => node.Links.Count >= 2);
        Node node1 = candidate2.DefaultIfEmpty(new Node(-1)).FirstOrDefault();
        if(node1.Val == -1) node1 = candidate.Where(node => node.Links.Count > 0).First();
        Console.Error.WriteLine("node1: {0} {1}", node1.Val, node1.ToString());
        candidate = node1.Links.OrderBy(node => node.DistanceFromGateway[0]);
        Console.Error.WriteLine("before thenby");
        Console.Error.WriteLine("gatewayList.Count: {0}", gatewayList.Count);
        //if(gatewayList.Count >= 2) candidate = candidate.ThenBy(node => node.DistanceFromGateway[1]);
        
        for (int i = 1; i < gatewayList.Where(gateway => gateway.Links.Count() > 0).ToList().Count - 1; i++)
        {
            Console.Error.WriteLine("bi: {0}", i);
            candidate = candidate.ThenBy(node => node.DistanceFromGateway[i]);
            Console.Error.WriteLine("ai: {0}", i);
        }
        
        Console.Error.WriteLine("after thenby");
        Console.Error.WriteLine("candidate.Count: {0}", candidate.Count());
        Node node2 = candidate.First();
        Console.Error.WriteLine("node2: {0} {1}", node2.Val, node2.ToString());
        CutLinkBetween(node1, node2);
        return Tuple.Create(node1, node2);
    }

    private void CutLinkBetween(Node node1, Node node2)
    {
        node1.Links.Remove(node2);
        node2.Links.Remove(node1);
    }

    private void CalculateDistanceFromAgent (int SI)
    {
        foreach (Node node in network) node.DistanceFromAgent = int.MaxValue;
        network[SI].DistanceFromAgent = 0;
        foreach (Node node in network[SI].Links) DistributeDistanceFromAgent(node, 1);
    }
    private void DistributeDistanceFromAgent (Node node, int distance)
    {
        if(node.DistanceFromAgent > distance)
        {
            node.DistanceFromAgent = distance++;
            foreach (Node nextNode in node.Links) DistributeDistanceFromAgent(nextNode, distance);
        }
    }

    private void CalculateDistanceFromGateway ()
    {
        foreach (Node node in network) node.DistanceFromGateway.Clear();
        foreach (Node gateway in gatewayList)
        {
            int roop = 0;
            foreach (Node node in network) node.TemporaryDistance = int.MaxValue;
            //Console.Error.WriteLine("gatewayList.Count: {0}, node{1}", gatewayList.Count, gateway.ToString());
            gateway.TemporaryDistance = 0;
            gateway.DistanceFromGateway.Add(0);
            foreach (Node node in gateway.Links) DistributeDistanceFromGateway(node, 1, roop);
            roop++;
        }
    }
    private void DistributeDistanceFromGateway (Node node, int distance, int roop)
    {
        if(node.TemporaryDistance > distance)
        {
            if(node.DistanceFromGateway.Count > roop) node.DistanceFromGateway.Remove(node.TemporaryDistance);
            node.TemporaryDistance = distance++;
            node.DistanceFromGateway.Add(node.TemporaryDistance);
            foreach (Node nextNode in node.Links) DistributeDistanceFromGateway(nextNode, distance, roop);
        }
    }

    public class Node
    {
        internal int Val {get; set;}
        internal bool IsGateway {get; set;}
        internal List<Node> Links {get; set;} = new List<Node>();
        internal int DistanceFromAgent {get; set;} = 0;
        internal int TemporaryDistance {get; set;}
        internal List<int> DistanceFromGateway {get; set;} = new List<int>();
        public Node (int num)
        {
            this.Val = num;
        }
        public override string ToString(){
            return string.Format("[num: {0}, links: {1}, DistanceFromAgent: {2}, DistanceFromGateway: ({3}), Gateway: {4}]"
            , Val, Links.Count, DistanceFromAgent, string.Join(" ", DistanceFromGateway), IsGateway);
        }
    }
}

