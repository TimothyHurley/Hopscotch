using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndMenu_Display : MonoBehaviour
{
    public Text scoreText; // Displays player's score.
    
    public int scoreFinal; // Player's final score.

    // Gets value for scoreFinal from TransferValues script.
    void Start()
    {
        scoreFinal = GameObject.FindGameObjectWithTag("Values").GetComponent<TransferValues>().scoreFinal;
        scoreText.text = ("Score: " + scoreFinal);
    }

    // Loads the SampleScene.
    public void LoadSample()
    {
        SceneManager.LoadScene("SampleScene");
    }

    // Loads the StartMenuScene.
    public void LoadStart()
    {
        SceneManager.LoadScene("StartMenuScene");
    }
}
