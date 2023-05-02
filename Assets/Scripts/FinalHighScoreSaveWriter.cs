/*
    FinalHighScoreSaveWriter.cs Saves/writes the highscores to the text document
    if the players score is high enough. Can clear all scores from the board.
*/
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using UnityEditor;

public class FinalHighScoreSaveWriter : MonoBehaviour
{
    public int NumberOfHighScores = 10;

    public void WriteHighScores(){
        string savePath = "Assets/FinalHighScores.txt";
        string line;
        string[] fields;
        int WrittenScoresSoFar = 0;
        string HighScoreNewName = FinalIntroDataManager.UserName;
        string HighScoreNewNum = FinalGameDataManager.UserHighScore.ToString();
        string[] HighScoreWriteNames = new string[10];
        string[] HighScoreWriteNums = new string[10];
        bool NewScoreWritten = false;

        StreamReader reader = new StreamReader(savePath);
        while (!reader.EndOfStream ) {
            line = reader.ReadLine();
            fields = line.Split(':');
            if (fields[1] == ""){
                fields[1] = "0";
            }
            if (!NewScoreWritten && WrittenScoresSoFar < NumberOfHighScores) {
                if(Convert.ToInt32(HighScoreNewNum) > Convert.ToInt32(fields[1])) {
                    HighScoreWriteNames[WrittenScoresSoFar] = HighScoreNewName;
                    HighScoreWriteNums[WrittenScoresSoFar] = HighScoreNewNum;
                    NewScoreWritten = true;
                    WrittenScoresSoFar += 1;
                }
            }
            if(WrittenScoresSoFar < NumberOfHighScores) {
                HighScoreWriteNames[WrittenScoresSoFar] = fields[0];
                HighScoreWriteNums[WrittenScoresSoFar] = fields[1];
                WrittenScoresSoFar += 1;
            }
        }
        
        reader.Close();
        StreamWriter writer = new StreamWriter(savePath);
        for(int x = 0; x < WrittenScoresSoFar; x++) {
            writer.WriteLine(HighScoreWriteNames[x] + ':' + HighScoreWriteNums[x]);
        }
        writer.Close();
        AssetDatabase.ImportAsset(savePath);
        TextAsset asset = (TextAsset)Resources.Load("scores");
    }

    public void ClearScores(){
        string savePath = "Assets/FinalHighScores.txt";
        StreamWriter writer = new StreamWriter(savePath);
        for(int x = 0; x < 10; x++) {
            writer.WriteLine("" + ':' + "");
        }
        writer.Close();
        AssetDatabase.ImportAsset(savePath);
        TextAsset asset = (TextAsset)Resources.Load("scores");
    }
}
/*

Template for filling high scores text document:

Jeb : 100
John : 90
Bog : 80
Hale : 70
Jerry : 60
Luke : 50
Dave : 40
Manny : 30
Kate : 20
Neb : 10
*/