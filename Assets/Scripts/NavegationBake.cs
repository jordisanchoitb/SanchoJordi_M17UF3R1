using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;

public class NavegationBake : MonoBehaviour
{
    private NavMeshSurface navMeshSurface;
    private void Start()
    {
        navMeshSurface = GetComponent<NavMeshSurface>();
        navMeshSurface.navMeshData = null;
    }

    public void BakeNavMesh()
    {
        navMeshSurface.BuildNavMesh();
    }
}
