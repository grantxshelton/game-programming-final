using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    ///public static float time;
    public Text timeDisplay;
    public static float timeRemaining;
    void Start()
    {
        timeRemaining = SliderChange.sliderValue;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
           
        }

        timeDisplay.text = "Time Remaining: " + (timeRemaining).ToString("#") + "s";
    }
}
