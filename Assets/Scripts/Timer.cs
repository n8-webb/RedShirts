using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public float timeLeft = 30.0f;
    public Text timeText;

    //Need scenemanagment script

    // Use this for initialization
    void Start()
    {

    }


    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft > 0)
        {
            timeText.text = timeLeft.ToString("F2"); //Formats the timer to 00:00
            //RoundEnd();
        }
        else
        {
            timeLeft = 0;

        }
    }

    void RoundEnd() //Called when the timer reaches 0
    {

    }
}