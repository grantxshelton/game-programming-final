using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesController : MonoBehaviour
{
    // Start is called before the first frame update
    public Text LivesDisplay;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LivesDisplay.text = LivesDropdown.lives.ToString();
    }
}
