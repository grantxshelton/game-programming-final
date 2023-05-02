using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;

public class HighScores : MonoBehaviour
{
    public Text HighScoresText;
    public int num_scores = 10;

    void Update()
    {
        string path = "Assets/scores.txt";
        string line;
        string[] fields;
        string[] playerNames = new string[num_scores];
        int[] playerScores = new int[num_scores];
        int scores_read = 0;

        HighScoresText.text = ""; // clear the scores box

        StreamReader reader = new StreamReader(path);
        while (!reader.EndOfStream && scores_read < num_scores)
        {
            line = reader.ReadLine();
            fields = line.Split(',');
            HighScoresText.text += fields[0] + " : " + fields[1] + "\n";
            scores_read += 1;
        }
        reader.Close();
    }
    public void ClearHighScores()
    {
        string path = "Assets/scores.txt";
        string[] lines = new string[10];
        for (int i = 0; i < lines.Length; i++)
        {
            lines[i] = "AAA,000";
        }
        File.WriteAllLines(path, lines);
    }
}
