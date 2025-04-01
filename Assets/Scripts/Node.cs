using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public Vector3Int Vector3Int { get; set; }
    public List<Node> Neighbors { get; set; }
    public Node(Vector3Int vector3Int)
    {
        Vector3Int = vector3Int;
        Neighbors = new List<Node>();
    }
}
