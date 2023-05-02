using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playernamecontroller : MonoBehaviour
{
    public Text playerText;
    void Start()
    {
        playerText.text = "Currently Playing: " + ReadInput.playerName;
    }
}
