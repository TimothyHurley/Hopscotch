using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile_Spawn : MonoBehaviour
{
    public GameObject[] tile; // Coloured tile prefabs.

    public List<GameObject> clone1 = new List<GameObject>(); // List of tiles in column 1.
    public List<GameObject> clone2 = new List<GameObject>(); // List of tiles in column 2.

    public float row = 0; // Z value of a given row of tiles. Starts at 0.

    public int count = 0; // Total number of tiles. Starts at 0.
    public int increase = 8; // Z value increases by x amount per row of tiles.
    public int limit = 4; // Limits number of tiles to x amount per column.
    public int limitGreen = 7; // Limits number of green tiles to 1 per x amount of tiles.
    public int number; // Random number determines tile colour (0 = red, 1 = amber, 2 = green).


    void Awake()
    {
        Spawn();
    }

    public void Spawn()
    {
        Spawn1();
        Spawn2();
    }

    // Spawns tiles in column 1 until limit is reached.
    public void Spawn1()
    {
        for (int i = 0; i < limit; i++)
        {
            Vector3 spawn1 = new Vector3(0, 0, i * increase + row);
            number = Random.Range(0, 3);

            if (number == 0)
            {
                clone1.Add(Instantiate(tile[0], spawn1, Quaternion.identity));
                limitGreen++;
            }

            if (number == 1)
            {
                clone1.Add(Instantiate(tile[1], spawn1, Quaternion.identity));
                limitGreen++;
            }

            if (number == 2)
            {
                if (limitGreen >= 7)
                {
                    clone1.Add(Instantiate(tile[2], spawn1, Quaternion.identity));
                    limitGreen = 0;
                }

                else
                {
                    number = Random.Range(0, 2);

                    if (number == 0)
                    {
                        clone1.Add(Instantiate(tile[0], spawn1, Quaternion.identity));
                        limitGreen++;
                    }

                    if (number == 1)
                    {
                        clone1.Add(Instantiate(tile[1], spawn1, Quaternion.identity));
                        limitGreen++;
                    }
                }
            }

            count++;
        }
    }

    // Spawns tiles in column 2 until limit is reached.
    public void Spawn2()
    {
        for (int i = 0; i < limit; i++)
        {
            Vector3 spawn2 = new Vector3(6, 0, i * increase + row);
            number = Random.Range(0, 3);

            if (number == 0)
            {
                clone2.Add(Instantiate(tile[0], spawn2, Quaternion.identity));
                limitGreen++;
            }

            if (number == 1)
            {
                clone2.Add(Instantiate(tile[1], spawn2, Quaternion.identity));
                limitGreen++;
            }

            if (number == 2)
            {
                if (limitGreen >= 7)
                {
                    clone2.Add(Instantiate(tile[2], spawn2, Quaternion.identity));
                    limitGreen = 0;
                }

                else
                {
                    number = Random.Range(0, 2);

                    if (number == 0)
                    {
                        clone2.Add(Instantiate(tile[0], spawn2, Quaternion.identity));
                        limitGreen++;
                    }

                    if (number == 1)
                    {
                        clone2.Add(Instantiate(tile[1], spawn2, Quaternion.identity));
                        limitGreen++;
                    }
                }
            }

            count++;
        }
    }
}
