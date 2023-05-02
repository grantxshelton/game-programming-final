using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesDropdown : MonoBehaviour
{
    // Start is called before the first frame update
    public Dropdown livesDropdown;
    public static int lives;
    public Text livestext;
    public void ChooseLives()
    {
        switch (livesDropdown.value)
        {
            case 1:
                lives = 1;
                break;
            case 2:
                lives = 2;
                break;
            case 3:
                lives = 3;
                break;
            case 4:
                lives = 4;
                break;
            case 5:
                lives = 5;
                break;
            case 6:
                lives = 6;
                break;
            case 7:
                lives = 7;
                break;
            case 8:
                lives = 8;
                break;
            case 9:
                lives = 9;
                break;

        }
    }

    // Update is called once per frame
    void Update()
    {
        livestext.text = "Lives: " + lives.ToString();
    }
}
