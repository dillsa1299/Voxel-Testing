using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    private WorldGenerator worldGen;
    private MeshGenerator meshGenerator;

    private int[,,] worldArray;

    public int worldSizeX = 10;
    public int worldSizeY = 10;
    public int worldSizeZ = 10;

    void Start()
    {
        worldGen = gameObject.GetComponent<WorldGenerator>();
        meshGenerator = gameObject.GetComponent<MeshGenerator>();

        //Create 3D array to represent world
        worldArray = worldGen.getWorld(worldSizeX, worldSizeY, worldSizeZ);
    }

    // Update is called once per frame
    void Update()
    {
        meshGenerator.RenderWorld(worldArray);
        if (Input.GetMouseButtonDown(0))
        {
            worldArray = worldGen.getWorld(worldSizeX, worldSizeY, worldSizeZ);
        }
    }
}
