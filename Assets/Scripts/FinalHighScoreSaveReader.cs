/*
    FinalHighScoreSaveReader.cs Displays highscore data saved in the
    text file.
*/
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;

public class FinalHighScoreSaveReader : MonoBehaviour
{
    public Text ListOfHighScores;
    public int Scores = 10;

    void Start(){
        Invoke("ScoreDisplayer", 0.0000001f);
    }

    public void ScoreDisplayer(){
        string savePath = "Assets/FinalHighScores.txt";
        string line;
        string[] fields;
        int displayedScores = 0;

        ListOfHighScores.text = "";

        StreamReader reader = new StreamReader(savePath);
        while(!reader.EndOfStream && displayedScores < Scores){
            line = reader.ReadLine();
            fields = line.Split(':');
            ListOfHighScores.text += fields[0] + " : " + fields[1] + "\n";
            displayedScores += 1;
        }
        reader.Close();
    }
}
