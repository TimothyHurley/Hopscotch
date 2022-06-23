using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TransferValues : MonoBehaviour
{
    public int scoreFinal; // Player's final score.
    
    // Ensures object and script values are not destroyed when scene transitions from SampleScene.
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "SampleScene")
        {
            DontDestroyOnLoad(this.gameObject);
        }

        else
        {
            Destroy(this.gameObject);
        }
    }

    // Gets value for scoreFinal from Player_Controls script.
    public void TransferScore()
    {
        scoreFinal = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Controls>().score;
    }
}
