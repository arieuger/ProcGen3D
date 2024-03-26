using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeCell : MonoBehaviour
{

    public IntVector2 coordinates;
    private MazeCellEdge[] _edges = new MazeCellEdge[MazeDirections.Count];
    private int _initializedEdgeCount;

    public MazeCellEdge GetEdge(MazeDirection direction)
    {
        return _edges[(int)direction];
    }

    public bool IsFullyInitialized
    {
        get
        {
            return _initializedEdgeCount == MazeDirections.Count;
        }
    }

    public void SetEdge(MazeDirection direction, MazeCellEdge edge)
    {
        _edges[(int)direction] = edge;
        _initializedEdgeCount += 1;
    }
    
    public MazeDirection RandomUninitializedDirection {
        get {
            int skips = Random.Range(0, MazeDirections.Count - _initializedEdgeCount);
            for (int i = 0; i < MazeDirections.Count; i++) {
                if (_edges[i] == null) {
                    if (skips == 0) {
                        return (MazeDirection)i;
                    }
                    skips -= 1;
                }
            }
            throw new System.InvalidOperationException("MazeCell has no uninitialized directions left.");
        }
    }
}
