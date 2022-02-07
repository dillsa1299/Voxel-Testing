using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Voxel : MonoBehaviour
{
    //world position is bottom-front-left of cube
    public float worldX = 0;
    public float worldY = 0;
    public float worldZ = 0;

    private Vector3[] vertices;
    private int[] triangles;
    // Start is called before the first frame update
    void Start()
    {
        triangles = new[]
        {
            //Front
            0, 4, 5,
            0, 1, 5,
            //Top
            4, 6, 7,
            4, 5, 7,
            //Right
            1, 5, 7,
            1, 3, 7,
            //Left
            2, 6, 4,
            2, 0, 4,
            //Back
            3, 7, 6,
            3, 2, 6,
            //Bottom
            0, 2, 3,
            0, 1, 3
        };
    }

    void Update()
    {
        vertices = new[]
        {
            new Vector3(worldX, worldY, worldZ), //0 Bottom-front-left
            new Vector3(worldX+1, worldY, worldZ), //1 Bottom-front-right
            new Vector3(worldX, worldY+1, worldZ), //2 Bottom-back-left
            new Vector3(worldX+1, worldY+1, worldZ), //3 Bottom-back-right
            new Vector3(worldX, worldY, worldZ+1), //4 Top-front-left
            new Vector3(worldX+1, worldY, worldZ+1), //5 Top-front-right
            new Vector3(worldX, worldY+1, worldZ+1), //6 Top-back-left
            new Vector3(worldX+1, worldY+1, worldZ+1) //7 Top-back-right
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
}
