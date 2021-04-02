using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class GraphComponents : MonoBehaviour
{
    public GameObject cube0, cube1, cube2, cube3, sphere0, sphere1, sphere2, sphere3, triang0, triang1, triang2, triang3, Cylinder, Cylinder0, Cylinder1, Cylinder2, Cylinder3, Cylinder4, Cylinder5;
    public GameObject camera;
    private Graph graph;
    public int IDcounter = 0;
    public int currentLayer = 0;
    public int mymethod()
    {
        IDcounter += 1;
        return IDcounter;
    }
    public void moveCam()
    {
        currentLayer += 1;
    }
    // Start is called before the first frame update
    void Start()
    {
        camera.transform.position = new Vector3(0, 0.5f, -2);
        currentLayer = 0;
        IDcounter = 0;
        GameObject[] allObjects = GameObject.FindGameObjectsWithTag("clone");
        foreach (GameObject obj in allObjects)
        {
            DestroyImmediate(obj);
        }
        int N_layers = 10;
        List<Color> colorlist = new List<Color>();
        colorlist.Add(Color.blue);
        colorlist.Add(Color.red);
        colorlist.Add(Color.yellow);
        colorlist.Add(Color.magenta);

        bool SameNodes =false;
        int nodeType=0;
        int color = 0;
        graph = new Graph();
        var node_start = new Node() { NodeColor = Color.green, NodePos = Vector2.zero };
        graph.Nodes.Add(node_start);
        // create nodes layer wise and store layers
        int counter = 0;
        for (var i = 1; i < N_layers; i++)
        {
            int rValue = Random.Range(0,100);   
            int N_nodes;
            if (rValue < 25) N_nodes = 2;
            else if (rValue < 60) N_nodes = 3;
            else N_nodes = 4;
            graph.NodesPerLayer.Add(N_nodes);
            List<Node> NodesInLayer = new List<Node>();
            if (Random.Range(0, 5) == 1) { SameNodes = true; color = Random.Range(0, 4); nodeType = Random.Range(0, 3); }
            else SameNodes = false;
            for (var j = 0; j < N_nodes; j++) 
            {
                if (SameNodes == true)
                {
                    var temp = new Node() { ID=counter,nodeType=nodeType, NodeColor = colorlist[color], NodePos = new Vector2((float)j - 0.5f * (N_nodes - 1) + Random.Range(-1, 2) * 0.0f, i + Random.Range(-1, 2) * 0.0f) };
                    NodesInLayer.Add(temp);
                    graph.Nodes.Add(temp);
                }
                else
                {
                    var temp = new Node() { nodeType = Random.Range(0, 3), NodeColor = colorlist[Random.Range(0,4)], NodePos = new Vector2((float)j-0.5f*(N_nodes-1)+Random.Range(-1,2)*0.0f, i + Random.Range(-1, 2) * 0.0f) };
                    NodesInLayer.Add(temp);
                    graph.Nodes.Add(temp);
                }
                counter += 1;
            }
            graph.Layers.Add(NodesInLayer);
        }
        var node_end = new Node() { NodeColor = Color.green, NodePos = new Vector2(0,N_layers) };
        graph.Nodes.Add(node_end);
        // create edges layer wise from bottom up
        foreach (Node node in graph.Layers[0])
        {
            Edge conn = new Edge() { LeftNode = node_start, RightNode = node, EdgeColor = Color.black };
            graph.Edges.Add(conn);

        }
        for (int i = 0; i < N_layers-2; i++)
        {   // outer edges
            var layer = graph.Layers[i];
            var nextlayer = graph.Layers[i+1];
            Edge outer1 = new Edge() { LeftNode = layer[0], RightNode = nextlayer[0], EdgeColor = Color.black };
            Edge outer2 = new Edge() { LeftNode = layer[graph.NodesPerLayer[i] - 1], RightNode = nextlayer[graph.NodesPerLayer[i+1]- 1], EdgeColor = Color.black };
            nextlayer[graph.NodesPerLayer[i + 1] - 1].Connected = graph.NodesPerLayer[i] - 1;
            layer[graph.NodesPerLayer[i] - 1].Connected = graph.NodesPerLayer[i + 1] - 1;
            nextlayer[0].Connected = 0;
            layer[0].Connected = 0;
            graph.Edges.Add(outer1);
            graph.Edges.Add(outer2);
            int diff = graph.NodesPerLayer[i] - graph.NodesPerLayer[i + 1];
            if (diff != 0)
            {   
                if (diff < 0)
                {   //flip
                    List<Node> temp = nextlayer;
                    nextlayer = layer;
                    layer = temp;
                }
                // start connecting from left 
                int posi = Random.Range(0, 1+1);
                Edge inner1 = new Edge() { LeftNode = layer[1], RightNode = nextlayer[posi], EdgeColor = Color.black };
                graph.Edges.Add(inner1);
                nextlayer[posi].Connected = 1;
                layer[1].Connected = posi;
                int nodepos = 0;
                foreach (Node node in layer)
                {
                    if (node.Connected == 100)
                    {
                        bool done = false;
                        int nextnodepos = 0;
                        // force connect if next layer has unconnected nodes
                        foreach (Node nextnode in nextlayer)
                        {
                            if (nextnode.Connected == 100)
                            {
                                Edge inner3 = new Edge() { LeftNode = node, RightNode = nextnode, EdgeColor = Color.black };
                                graph.Edges.Add(inner3);
                                node.Connected = nextnodepos;
                                nextnode.Connected = nodepos;
                                done = true;
                            }
                            nextnodepos += 1;
                        }
                        // choose between neighboring connections
                        if (done == false)
                        {
                            int min = layer[nodepos-1].Connected;
                            int max = layer[nodepos + 1].Connected;
                            int posi2 = Random.Range(min, max + 1);
                            Edge inner3 = new Edge() { LeftNode = node, RightNode = nextlayer[posi2], EdgeColor = Color.black };
                            graph.Edges.Add(inner3);
                        }
                    }
                    nodepos += 1;
                }

            }
            else // for same layer sizes
            {
                if (layer.Count == 3)
                {
                    int which = Random.Range(0, 3);
                    Node node = layer[which];
                    if (which == 1)
                    {   
                        int nextnodepos = Random.Range(0, 2) * 2;
                        Edge conn = new Edge() { LeftNode = node, RightNode = nextlayer[nextnodepos], EdgeColor = Color.black };
                        graph.Edges.Add(conn);
                        node.Connected = nextnodepos;
                        Edge conn2 = new Edge() { LeftNode = node, RightNode = nextlayer[1], EdgeColor = Color.black };
                        graph.Edges.Add(conn2);
                    }
                    else
                    {
                        Edge conn = new Edge() { LeftNode = node, RightNode = nextlayer[1], EdgeColor = Color.black };
                        graph.Edges.Add(conn);
                        node.Connected = 1;
                    }
                    int nodepos = 0;
                    foreach (Node n in layer)
                    {
                        if (n.Connected == 100)
                        {   // choose between neighboring connections
                            int nextnodepos=Random.Range(layer[nodepos - 1].Connected, layer[nodepos + 1].Connected+1);
                            Edge inner = new Edge() { LeftNode = n, RightNode = nextlayer[nextnodepos], EdgeColor = Color.black };
                            graph.Edges.Add(inner);
                            node.Connected = nextnodepos;
                            nextlayer[nextnodepos].Connected = nodepos;
                        }
                        nodepos += 1;
                    }
                }
                else if (layer.Count == 4)
                {
                    int which = Random.Range(0, 4);
                    Node node = layer[which];
                    if (which == 0)
                    {
                        Edge conn = new Edge() { LeftNode = node, RightNode = nextlayer[1], EdgeColor = Color.black };
                        graph.Edges.Add(conn);
                        nextlayer[1].Connected = 0;
                        node.Connected = 1;
                    }
                    else if (which == 3)
                    {
                        Edge conn = new Edge() { LeftNode = node, RightNode = nextlayer[2], EdgeColor = Color.black };
                        graph.Edges.Add(conn);
                        nextlayer[2].Connected = 3;
                        node.Connected = 2;
                    }
                    else
                    {
                        Edge conn = new Edge() { LeftNode = node, RightNode = nextlayer[which], EdgeColor = Color.black };
                        graph.Edges.Add(conn);
                        nextlayer[which].Connected = which;
                        int randi = Random.Range(0, 2) * 2 - 1;
                        Edge conn2 = new Edge() { LeftNode = node, RightNode = nextlayer[which+randi], EdgeColor = Color.black };
                        graph.Edges.Add(conn2);
                        if (which == 1){node.Connected = System.Math.Max(which, which + randi);}
                        else{node.Connected = System.Math.Min(which, which + randi);}
                    }
                    int nodepos = 0;
                    // connect remaining nodes from layer
                    foreach (Node n in layer)
                    {
                        if (n.Connected == 100)
                        {
                            bool done = false;
                            int nextnodepos = 0;
                            // force connect if next layer has unconnected nodes
                            foreach (Node next in nextlayer)
                            {   
                                if (next.Connected == 100)
                                {
                                    Edge inner = new Edge() { LeftNode = n, RightNode = next, EdgeColor = Color.black };
                                    graph.Edges.Add(inner);
                                    n.Connected = nextnodepos;
                                    next.Connected = nodepos;
                                    done = true;
                                }
                                nextnodepos += 1;
                            }
                            // neighbor has no connection yet
                            if (layer[nodepos + 1].Connected >3&&done==false)
                            {
                                nextnodepos = Random.Range(layer[nodepos - 1].Connected, layer[nodepos - 1].Connected+2);
                                Edge inner = new Edge() { LeftNode = n, RightNode = nextlayer[nextnodepos], EdgeColor = Color.black };
                                graph.Edges.Add(inner);
                                node.Connected = nextnodepos;
                                nextlayer[nextnodepos].Connected = nodepos;
                            }
                            else if (done==false)
                            {
                                nextnodepos = Random.Range(layer[nodepos - 1].Connected, layer[nodepos + 1].Connected+1);
                                Edge inner = new Edge() { LeftNode = n, RightNode = nextlayer[nextnodepos], EdgeColor = Color.black };
                                graph.Edges.Add(inner);
                                node.Connected = nextnodepos;
                                nextlayer[nextnodepos].Connected = nodepos;
                            }
                        }
                        nodepos += 1;
                    }
                }
            }
            // reset connections
            foreach (Node node in nextlayer){node.Connected = 100;}
            foreach (Node node in layer){node.Connected = 100;}
        }
        // connect boss node
        foreach (Node node in graph.Layers[N_layers - 2])
        {
            Edge conn = new Edge() { LeftNode = node, RightNode = node_end, EdgeColor = Color.black };
            graph.Edges.Add(conn);
        }

        foreach(Node node in graph.Nodes)
        {
            switch (node.nodeType)
            {
                case 0:
                    if (node.NodeColor == Color.blue) { Instantiate(cube0, node.NodePos, Quaternion.identity); }
                    else if (node.NodeColor == Color.red) { Instantiate(cube1, node.NodePos, Quaternion.identity); }
                    else if (node.NodeColor == Color.yellow) { Instantiate(cube2, node.NodePos, Quaternion.identity); }
                    else if (node.NodeColor == Color.magenta) { Instantiate(cube3, node.NodePos, Quaternion.identity); }
                    break;
                case 1:
                    if (node.NodeColor == Color.blue) {Instantiate(sphere0, node.NodePos, Quaternion.identity); }
                    else if (node.NodeColor == Color.red) {  Instantiate(sphere1, node.NodePos, Quaternion.identity); }
                    else if (node.NodeColor == Color.yellow) { Instantiate(sphere2, node.NodePos, Quaternion.identity); }
                    else if (node.NodeColor == Color.magenta) { Instantiate(sphere3, node.NodePos, Quaternion.identity); }
                    break;
                case 2:
                    if (node.NodeColor == Color.blue) {Instantiate(triang0, node.NodePos, Quaternion.identity); }
                    else if (node.NodeColor == Color.red) { Instantiate(triang1, node.NodePos, Quaternion.identity); }
                    else if (node.NodeColor == Color.yellow) {  Instantiate(triang2, node.NodePos, Quaternion.identity); }
                    else if (node.NodeColor == Color.magenta) {Instantiate(triang3, node.NodePos, Quaternion.identity); }
                    break;
                default:
                    break;
            }
            
        }
        GameObject[] allObjects2 = GameObject.FindGameObjectsWithTag("clone");
        foreach (GameObject obj in allObjects2)
        {
            obj.transform.localScale=new Vector3(0.2f,0.2f,0.2f);
        }
        foreach (Edge edge in graph.Edges)
        {
            var temp1 = edge.LeftNode.NodePos;
            var temp2 = edge.RightNode.NodePos;
            if (temp1[1] > temp2[1]) {
                temp2 = edge.LeftNode.NodePos;
                temp1 = edge.RightNode.NodePos;
            }
            var diff = temp1[0] - temp2[0];
            if (0.01f>diff && diff>-0.01f) { Instantiate(Cylinder, temp1, Quaternion.identity); }
            else if (0.01f+0.5f > diff && diff > -0.01f+0.5f) { Instantiate(Cylinder3, temp1, Quaternion.identity); }
            else if (0.01f+1 > diff && diff > -0.01f+1) { Instantiate(Cylinder4, temp1, Quaternion.identity); }
            else if (0.01f+1.5 > diff && diff > -0.01f+1.5) { Instantiate(Cylinder5, temp1, Quaternion.identity); }
            else if (0.01f - 0.5f > diff && diff > -0.01f- 0.5f) { Instantiate(Cylinder0, temp1, Quaternion.identity); }
            else if (0.01f - 1 > diff && diff > -0.01f - 1) { Instantiate(Cylinder1, temp1, Quaternion.identity); }
            else if (0.01f - 1.5 > diff && diff > -0.01f - 1.5) { Instantiate(Cylinder2, temp1, Quaternion.identity); }
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (graph == null)
        {
            Start();
        }
        if (camera.transform.position.y < currentLayer)
        {
            camera.transform.position = new Vector3(0, camera.transform.position.y+Time.deltaTime, -2);
        }
        else
        {
            camera.transform.position = new Vector3(0, currentLayer, -2);
        }

    }
}
