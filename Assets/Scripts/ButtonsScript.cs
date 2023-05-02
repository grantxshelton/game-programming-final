using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsScript : MonoBehaviour
{
    //Method for going to next scene
    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void DonePlaying()
    {
        GameObject pointObject = GameObject.Find("Points Controller"); 
        Points pointScript = pointObject.GetComponent<Points>();
        pointScript.AddNewScore();
        SceneManager.LoadScene("3Exit");
    }
    public void Replay()
    {
        Points.points = 0;
        Timer.timeRemaining = SliderChange.sliderValue;
        SceneManager.LoadScene("2Game");
    }
    public void ExitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }
    public void DecreasePoints()
    {
        Points.points--;
    }
    public void IncreasePoints()
    {
        Points.points++;
    }
    public void DecreaseLives()
    {
        LivesDropdown.lives--;
    }
    public void IncreaseLives()
    {
        LivesDropdown.lives++;
    }
}
