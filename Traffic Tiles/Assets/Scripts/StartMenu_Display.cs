using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu_Display : MonoBehaviour
{
    // Loads the SampleScene.
    public void LoadSample()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
