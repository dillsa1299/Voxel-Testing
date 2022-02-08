using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]

public class MeshGenerator : MonoBehaviour
{
    private Voxel voxel;
    private MeshFilter meshFilter;
    bool debug = true;

    void Start()
    {
        voxel = gameObject.GetComponent<Voxel>();
        meshFilter = GetComponent<MeshFilter>();
    }

    public void RenderWorld(int[,,] worldArray)
    {
        var vertices = new List<Vector3>();
        var triangles = new List<int>();
        var normals = new List<Vector3>();

        for (int x = 0; x < worldArray.GetLength(0); x += 1)
        {
            for (int y = 0; y < worldArray.GetLength(1); y += 1)
            {
                for (int z = 0; z < worldArray.GetLength(1); z += 1)
                {
                    var block = worldArray[x, y, z];//1=voxel, 0=air
                    //If air, skip
                    if (block == 0) continue;
                    //position of voxel in world
                    var worldPos = new Vector3(x, y, z);
                    var verticesPos = vertices.Count;

                    foreach (var vert in voxel.getVertices())
                        vertices.Add(worldPos + vert); //Voxel postion + cubes vertex
                    foreach (var tri in voxel.getTriangles())
                        triangles.Add(verticesPos + tri); //Position in vertices list for new vertex we just added
                    foreach (var normal in voxel.getNormals())
                        normals.Add(normal);
                }
            }
        }

        // Apply new mesh to MeshFilter
        var mesh = new Mesh();
        mesh.SetVertices(vertices);
        mesh.SetTriangles(triangles.ToArray(), 0);
        mesh.SetNormals(normals);

        Vector2[] uvs = new Vector2[vertices.Count];

        for (int i = 0; i < uvs.Length; i++)
        {
            uvs[i] = new Vector2(vertices[i].x, vertices[i].z);
        }

        if(debug)
        {
            Debug.Log(uvs.Length);
            debug=false;
        }
        mesh.uv = uvs;


        //mesh.uv = voxel.getUVs();
        meshFilter.mesh = mesh;
    }
}
