using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Vector2Int coordinates = new Vector2Int(2, 2);
    public bool isWalkable;
    public bool isExplored;
    public bool isPath;
    public Node connectedTo;

    public Node(Vector2Int _coordinates, bool _isWalkable)
    {
        _coordinates = coordinates;
        _isWalkable = isWalkable;


    }
}
