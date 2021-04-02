using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph
{
    public Graph()
    {
        Nodes = new List<Node>();
        Edges = new List<Edge>();
        Layers = new List<List<Node>>();

        NodesPerLayer = new List<int>();
    }

    public List<Node> Nodes { get; private set; }

    public List<Edge> Edges { get; private set; }

    public List<List<Node>> Layers { get; private set; }
    public List<int> NodesPerLayer { get; private set; }

}

public class Node
{
    public Node()
    {
        Connected = 100;
    }

    public Vector2 NodePos { get; set; }
    public Color NodeColor { get; set; }
    public int Connected { get; set; }
    public int nodeType { get; set; }
}

public class Edge
{
    public Node LeftNode { get; set; }
    public Node RightNode { get; set; }
    public Color EdgeColor { get; set; }
}

