using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Controls : MonoBehaviour
{
    public GameObject[] player; // Player's column_x colliders.
    public GameObject[] tile; // Coloured tile prefabs.

    public Text scoreText; // Displays player's score.

    public Transform[] spawn; // Player's column_x colliders.

    public List<GameObject> clone1 = new List<GameObject>(); // List of tiles in column 1.
    public List<GameObject> clone2 = new List<GameObject>(); // List of tiles in column 2.

    // Bools identify tile colour.
    public bool red1 = false;
    public bool amber1 = false;
    public bool green1 = false;

    public bool red2 = false;
    public bool amber2 = false;
    public bool green2 = false;

    public float playerZ = 0; // Player's z axis. Starts at 0.

    public int max = 4; // Maximum number of elements per list.
    public int score = 0; // Player's score. Starts at 0.


    // Gets values for clone1 and clone2 from Tile_Spawn script.
    void Start()
    {
        clone1 = GameObject.FindGameObjectWithTag("Spawn").GetComponent<Tile_Spawn>().clone1;
        clone2 = GameObject.FindGameObjectWithTag("Spawn").GetComponent<Tile_Spawn>().clone2;
    }

    // Checks for button inputs.
    void Update()
    {
        if (Input.GetKeyDown("a"))
        {
            Cycle1();
        }

        if (Input.GetKeyDown("d"))
        {
            Cycle2();
        }

        if (Input.GetKeyDown("w"))
        {
            CycleForward();
        }

        if (Input.GetKeyDown("s"))
        {
            CycleBackward();
        }
    }

    // Cycles tile in column 1 forward one colour (red --> amber --> green --> red).
    void Cycle1()
    {
        CheckColour();
        
        if (red1)
        {
            GameObject.Destroy(clone1[0]);
            clone1.Add(clone1[0] = Instantiate(tile[1], spawn[0].position, Quaternion.identity));
        }

        if (amber1)
        {
            GameObject.Destroy(clone1[0]);
            clone1.Add(clone1[0] = Instantiate(tile[2], spawn[0].position, Quaternion.identity));
        }

        if (green1)
        {
            GameObject.Destroy(clone1[0]);
            clone1.Add(clone1[0] = Instantiate(tile[0], spawn[0].position, Quaternion.identity));
        }

        CleanList();
        CheckColour();

        if (green1 && green2)
        {
            MoveTiles();
        }
    }

    // Cycles tile in column 2 forward one colour (red --> amber --> green --> red).
    void Cycle2()
    {
        CheckColour();

        if (red2)
        {
            GameObject.Destroy(clone2[0]);
            clone2.Add(clone2[0] = Instantiate(tile[1], spawn[1].position, Quaternion.identity));
        }

        if (amber2)
        {
            GameObject.Destroy(clone2[0]);
            clone2.Add(clone2[0] = Instantiate(tile[2], spawn[1].position, Quaternion.identity));
        }

        if (green2)
        {
            GameObject.Destroy(clone2[0]);
            clone2.Add(clone2[0] = Instantiate(tile[0], spawn[1].position, Quaternion.identity));
        }

        CleanList();
        CheckColour();

        if (green1 && green2)
        {
            MoveTiles();
        }
    }

    // Cycles tiles in columns 1 and 2 forward one colour (red --> amber --> green --> red).
    void CycleForward()
    {
        CheckColour();

        if (red1)
        {
            GameObject.Destroy(clone1[0]);
            clone1.Add(clone1[0] = Instantiate(tile[1], spawn[0].position, Quaternion.identity));
        }

        if (amber1)
        {
            GameObject.Destroy(clone1[0]);
            clone1.Add(clone1[0] = Instantiate(tile[2], spawn[0].position, Quaternion.identity));
        }

        if (green1)
        {
            GameObject.Destroy(clone1[0]);
            clone1.Add(clone1[0] = Instantiate(tile[0], spawn[0].position, Quaternion.identity));
        }

        if (red2)
        {
            GameObject.Destroy(clone2[0]);
            clone2.Add(clone2[0] = Instantiate(tile[1], spawn[1].position, Quaternion.identity));
        }

        if (amber2)
        {
            GameObject.Destroy(clone2[0]);
            clone2.Add(clone2[0] = Instantiate(tile[2], spawn[1].position, Quaternion.identity));
        }

        if (green2)
        {
            GameObject.Destroy(clone2[0]);
            clone2.Add(clone2[0] = Instantiate(tile[0], spawn[1].position, Quaternion.identity));
        }

        CleanList();
        CheckColour();

        if (green1 && green2)
        {
            MoveTiles();
        }
    }

    // Cycles tiles in columns 1 and 2 backward one colour (red --> green --> amber --> red).
    void CycleBackward()
    {
        CheckColour();

        if (red1)
        {
            GameObject.Destroy(clone1[0]);
            clone1.Add(clone1[0] = Instantiate(tile[2], spawn[0].position, Quaternion.identity));
        }

        if (amber1)
        {
            GameObject.Destroy(clone1[0]);
            clone1.Add(clone1[0] = Instantiate(tile[0], spawn[0].position, Quaternion.identity));
        }

        if (green1)
        {
            GameObject.Destroy(clone1[0]);
            clone1.Add(clone1[0] = Instantiate(tile[1], spawn[0].position, Quaternion.identity));
        }

        if (red2)
        {
            GameObject.Destroy(clone2[0]);
            clone2.Add(clone2[0] = Instantiate(tile[2], spawn[1].position, Quaternion.identity));
        }

        if (amber2)
        {
            GameObject.Destroy(clone2[0]);
            clone2.Add(clone2[0] = Instantiate(tile[0], spawn[1].position, Quaternion.identity));
        }

        if (green2)
        {
            GameObject.Destroy(clone2[0]);
            clone2.Add(clone2[0] = Instantiate(tile[1], spawn[1].position, Quaternion.identity));
        }

        CleanList();
        CheckColour();

        if (green1 && green2)
        {
            MoveTiles();
        }
    }

    // Identifies tile colour and sets bool values accordingly.
    void CheckColour()
    {
        if (clone1[0].tag == "Red")
        {
            red1 = true;
            amber1 = false;
            green1 = false;
        }

        if (clone1[0].tag == "Amber")
        {
            red1 = false;
            amber1 = true;
            green1 = false;
        }

        if (clone1[0].tag == "Green")
        {
            red1 = false;
            amber1 = false;
            green1 = true;
        }

        if (clone2[0].tag == "Red")
        {
            red2 = true;
            amber2 = false;
            green2 = false;
        }

        if (clone2[0].tag == "Amber")
        {
            red2 = false;
            amber2 = true;
            green2 = false;
        }

        if (clone2[0].tag == "Green")
        {
            red2 = false;
            amber2 = false;
            green2 = true;
        }
    }

    // Prevents lists from exceeding the maximum number of elements.
    void CleanList()
    {
        if (clone1.Count > max)
        {
            clone1.RemoveAt(max);
            
            CleanList();
        }

        if (clone2.Count > max)
        {
            clone2.RemoveAt(max);
            
            CleanList();
        }
    }

    // Calls on Tile_Move and Timer scripts to move tiles down 1 row and increase the timer, then updates the player's score and adds 1 tile at the top of each column.
    void MoveTiles()
    {
        green1 = false;
        green2 = false;

        for (int i = 0; i < max; i++)
        {
            clone1[i].GetComponent<Tile_Move>().Move();
            clone2[i].GetComponent<Tile_Move>().Move();
        }

        GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer>().AddTime();

        score++;
        scoreText.text = ("" + score);
        GameObject.FindGameObjectWithTag("Values").GetComponent<TransferValues>().TransferScore();

        clone1.RemoveAt(0);
        clone2.RemoveAt(0);

        CleanList();

        GameObject.FindGameObjectWithTag("Spawn").GetComponent<Tile_Spawn>().row = 24;
        GameObject.FindGameObjectWithTag("Spawn").GetComponent<Tile_Spawn>().count = 0;
        GameObject.FindGameObjectWithTag("Spawn").GetComponent<Tile_Spawn>().limit = 1;
        GameObject.FindGameObjectWithTag("Spawn").GetComponent<Tile_Spawn>().Spawn();
    }
}
