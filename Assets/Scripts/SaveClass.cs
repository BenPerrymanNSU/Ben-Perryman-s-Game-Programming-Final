/*
        SaveClass.cs Contains the save class used in FinalSaveLoader
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Save{
        public string PlayerName = "PlayerName";
        public int PlayerScore = 0;
        public int PlayerHighScore = 0;
        public float RemainingTime = 0f;
        public int PlayerLives = 0;
}