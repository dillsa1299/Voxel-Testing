using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGenerator : MonoBehaviour
{
    private int[,,] worldArray; //3D array to represent world

    //Randomly generates world
    //0 = air
    //1 = voxel
    private void genWorld()
    {
        for (int x = 0; x < worldArray.GetLength(0); x += 1)
        {
            for (int y = 0; y < worldArray.GetLength(1); y += 1)
            {
                for (int z = 0; z < worldArray.GetLength(1); z += 1)
                {
                    int rand = Random.Range(0, 4); //1 in 4 chance of voxel being generated
                    if (rand > 0)
                    {
                        worldArray[x, y, z] = 0;
                    } else {
                        worldArray[x, y, z] = 1;
                    }
                }
            }
        }
    }

    //Creates 3D array based on input parameters, randomly generates voxels and returns array
    public int[,,] getWorld(int rangeX, int rangeY, int rangeZ)
    {
        worldArray = new int[rangeX, rangeY, rangeZ];
        genWorld();
        return worldArray;
    }
}
