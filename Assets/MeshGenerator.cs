using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]

public class MeshGenerator : MonoBehaviour
{
    private VoxelData voxelData;
    private MeshFilter meshFilter;

    void Start()
    {
        voxelData = gameObject.GetComponent<VoxelData>();
        meshFilter = GetComponent<MeshFilter>();
    }

    public void RenderWorld(int[,,] worldArray)
    {
        var vertices = new List<Vector3>();
        var triangles = new List<int>();
        var normals = new List<Vector3>();

        for (int x = 0; x < worldArray.GetLength(0); x++)
        {
            for (int y = 0; y < worldArray.GetLength(1); y++)
            {
                for (int z = 0; z < worldArray.GetLength(1); z++)
                {
                    var block = worldArray[x, y, z];//1=voxel, 0=air
                    //If air, skip
                    if (block == 0) continue;
                    //position of voxel in world
                    var worldPos = new Vector3(x, y, z);
                    var verticesPos = vertices.Count;

                    foreach (var vert in voxelData.getVertices())
                        vertices.Add(worldPos + vert); //Voxel postion + cubes vertex
                    foreach (var tri in voxelData.getTriangles())
                        triangles.Add(verticesPos + tri); //Position in vertices list for new vertex we just added
                    foreach (var normal in voxelData.getNormals())
                        normals.Add(normal);
                }
            }
        }

        // Apply new mesh to MeshFilter
        var mesh = new Mesh();
        mesh.SetVertices(vertices);
        mesh.SetTriangles(triangles.ToArray(), 0);
        mesh.SetNormals(normals);
        meshFilter.mesh = mesh;
    }
}
