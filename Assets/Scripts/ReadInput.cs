using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadInput : MonoBehaviour
{
    public static ReadInput readInput;
    public InputField playerInput;
    public static string playerName;
    public Text playerText;

    public void Start()
    {
        playerText.text = "Playername: ";
        if (playerName != null)
        {
            playerName = playerName.ToUpper(); //Saves playername between scenes
        }
    }
    public void ReadStringInput()
    {
        playerName = playerInput.text.ToString(); //Sets string 'playerName' to input field text
        playerText.text = "Playername: " + playerName.ToUpper(); //Sets text on screen to playerName & uppercases it
    }
}
