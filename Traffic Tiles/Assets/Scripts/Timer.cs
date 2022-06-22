using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Slider timeBar; // Timer is represented by a bar that reduces over time.

    public float timeAdd = 0.8f; // Adds x seconds to timeLeft.
    public float timeLeft = 4f; // Amount of time left.
    public float timeMax = 4f; // Maximum amount of time (in seconds).
    

    void Start()
    {
        timeLeft = timeMax;
    }

    // Updates timer and transitions to EndMenuScene when timer ends.
    void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            timeBar.value = timeLeft / timeMax;
        }

        else
        {
            SceneManager.LoadScene("EndMenuScene");
        }
    }

    // Adds timeAdd to timeLeft.
    public void AddTime()
    {
        timeLeft = timeLeft + timeAdd;

        if (timeLeft > timeMax)
        {
            timeLeft = timeMax;
        }
    }
}
