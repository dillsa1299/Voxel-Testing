using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]

public class MeshGenerator : MonoBehaviour
{
    Voxel voxel;

    void Start()
    {
        voxel = gameObject.GetComponent<Voxel>();
    }

    void Update()
    {
        RenderCube();
    }

    private void RenderCube()
    {
        Mesh mesh = GetComponent<MeshFilter>().mesh;

        mesh.Clear();
        mesh.vertices = voxel.getVertices();
        mesh.triangles = voxel.getTriangles();

        // Search what these do
        mesh.Optimize();
        mesh.RecalculateNormals();
    }
}
