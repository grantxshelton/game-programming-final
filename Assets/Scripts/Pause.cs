
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    //public Text pauseText;
    public Canvas pauseCanvas;
    private bool isPaused = false;
   // public Canvas pauseCanvas;


    // Start is called before the first frame update
    void Start()
    {
        pauseCanvas.gameObject.SetActive(false); // hide the Resume button
        //pauseText.gameObject.SetActive(false); //hide pause text
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // ESC key pauses AND resumes
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
        if (!isPaused)
        {
            //pauseText.gameObject.SetActive(false); //hide pause text
        }
    }
    void PauseGame()
    {
        Time.timeScale = 0;
        isPaused = true;
        //pauseText.gameObject.SetActive(true); //show pause text
        pauseCanvas.gameObject.SetActive(true); // show the Resume button
    }
    public void ResumeGame() // called from ESC; also attached to the resume button
    {
        Time.timeScale = 1;
        isPaused = false;
        //pauseText.gameObject.SetActive(false); //hide pause text
        pauseCanvas.gameObject.SetActive(false); // hide the Resume button while playing
    }

    public void SaveGame()
    {
        Save save = CreateSaveGameObject();

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gamesave.save");
        bf.Serialize(file, save);
        file.Close();

    }
    public void SaveAsJSON()
    {
        Save save = CreateSaveGameObject();
        string json = JsonUtility.ToJson(save);

        Debug.Log("Saving as JSON: " + json);
    }

    private Save CreateSaveGameObject()
    {
        Save save = new Save();
        save.lives = LivesDropdown.lives;
        save.points = Points.points;
        return save;
    }

    public void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath + "/gamesave.save"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gamesave.save", FileMode.Open);
            Save save = (Save)bf.Deserialize(file);
            file.Close();

            LivesDropdown.lives = save.lives;
            Points.points = save.points;
        }
        else
        {
            Debug.Log("No game saved!");
        }
    }
    public void NewGame()
    {
        LivesDropdown.lives = 0;
        Points.points = 0;
    }

}