using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using UnityEditor;

public class Points : MonoBehaviour
{
    public static int points = 0;
    public int num_scores = 10;
    public Text pointsText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pointsText.text = points.ToString();
    }

    public void AddNewScore()
    {
        string path = "Assets/scores.txt";
        string line;
        string[] fields;
        int scores_written = 0;
        string newName = "don't forget to input";
        string newScore = "999";
        bool newScoreWritten = false;
        string[] writeNames = new string[10];
        int[] writeScores = new int[10];

        newName = ReadInput.playerName;
        if (ReadInput.playerName == null)
        {
            newName = "Player1";
        }
        newScore = points.ToString();

        StreamReader reader = new StreamReader(path);
        while (!reader.EndOfStream)
        {
            line = reader.ReadLine();
            fields = line.Split(',');
            if (!newScoreWritten && scores_written < num_scores) // if new score has not been written yet
            {
                //check if we need to write new higher score first
                if (Convert.ToInt32(newScore) > Convert.ToInt32(fields[1]))
                {
                    writeNames[scores_written] = newName;
                    writeScores[scores_written] = Convert.ToInt32(newScore);
                    newScoreWritten = true;
                    scores_written += 1;
                }
            }
            if (scores_written < num_scores) // we have not written enough lines yet
            {
                writeNames[scores_written] = fields[0];
                writeScores[scores_written] = Convert.ToInt32(fields[1]);
                scores_written += 1;
            }
        }
        reader.Close();

        if (!newScoreWritten && scores_written < num_scores) // if new score has not been written yet
        {
            writeNames[scores_written] = newName;
            writeScores[scores_written] = Convert.ToInt32(newScore);
            scores_written += 1;
        }

        // now we have parallel arrays with names and scores to write
        StreamWriter writer = new StreamWriter(path);

        for (int x = 0; x < scores_written; x++)
        {
            writer.WriteLine(writeNames[x] + ',' + writeScores[x]);
        }
        writer.Close();

        AssetDatabase.ImportAsset(path);
        TextAsset asset = (TextAsset)Resources.Load("scores");

    }
}
