using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoxelData : MonoBehaviour
{
    private Vector3[] vertices;
    private int[] triangles;
    private Vector3[] normals;
    private Vector2[] uvMapping;

    // Start is called before the first frame update
    void Start()
    {
        vertices = new[] //Vertices in the voxel
        {
            new Vector3 (0, 1, 0),
            new Vector3 (1, 0, 0),
            new Vector3 (1, 1, 0),
            new Vector3 (0, 1, 0),
            new Vector3 (0, 1, 1),
            new Vector3 (1, 1, 1),
            new Vector3 (1, 0, 1),
            new Vector3 (0, 0, 1),
        };

        triangles = new[] //Vertex groups that make each triangle
        {
            0, 2, 1, //face front
            0, 3, 2,
            2, 3, 4, //face top
            2, 4, 5,
            1, 2, 5, //face right
            1, 5, 6,
            0, 7, 4, //face left
            0, 4, 3,
            5, 4, 7, //face back
            5, 7, 6,
            0, 6, 7, //face bottom
            0, 1, 6
        };

        normals = new[] //Normals for lighting
        {
            Vector3.up,Vector3.up,Vector3.up,
            Vector3.up,Vector3.up,Vector3.up,
            Vector3.up,Vector3.up
        };

        //UV map = X,Y
        // 2x2 Grid, Bottom-Left = A, Bottom-Right = B, Top-Left = C
        uvMapping = new[]
        {
            //Top & Bottom (A)
			new Vector2(0, 0),
            new Vector2(0.499f, 0),
            new Vector2(0, 0.499f),
            new Vector2(0.499f, 0.499f),
            //Front & Back (B)
			new Vector2(0.499f, 0),
            new Vector2(1, 0),
            new Vector2(0.499f, 0.499f),
            new Vector2(1, 0.499f),
            //Left & Right (C)
			new Vector2(0, 0.5f),
            new Vector2(0.499f, 0.5f),
            new Vector2(0, 1),
            new Vector2(0.499f, 1)
		};	
    }

    public Vector3[] getVertices()
    {
        return vertices;
    }

    public int[] getTriangles()
    {
        return triangles;
    }

    public Vector3[] getNormals()
    {
        return normals;
    }

    public Vector2[] getUVs()
    {
        return uvMapping;
    }
}

public class TextureData
{
    //public VoxelType voxelType;
    public Vector2Int topBottom, frontBack, leftRight;
}
