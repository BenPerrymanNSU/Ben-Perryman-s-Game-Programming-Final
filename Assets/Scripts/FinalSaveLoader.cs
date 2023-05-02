/*
    FinalSaveLoader.cs Controls the saving and loading buttons
    found on the pause screen in the game scene.
*/
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

public class FinalSaveLoader : MonoBehaviour
{
    private Save CreateSave(){
        Save save = new Save();
        save.PlayerName = FinalIntroDataManager.UserName;
        save.PlayerScore = FinalGameDataManager.UserScore;
        save.PlayerHighScore = FinalGameDataManager.UserHighScore;
        save.RemainingTime = FinalIntroDataManager.TimerTime;
        save.PlayerLives = FinalIntroDataManager.Lives;

        return save;
    }

    public void SaveTheGame(){
        Save save = CreateSave();

        BinaryFormatter BinFor = new BinaryFormatter();
        FileStream file = File.Create("Assets/FinalGameSave.save");
        BinFor.Serialize(file, save);
        file.Close();
    }

    public void LoadTheGame(){
        if (File.Exists("Assets/FinalGameSave.save")){
            BinaryFormatter BinFor = new BinaryFormatter();
            FileStream file = File.Open("Assets/FinalGameSave.save", FileMode.Open);
            Save save = (Save)BinFor.Deserialize(file);
            file.Close();

            FinalIntroDataManager.UserName = save.PlayerName;
            FinalGameDataManager.UserScore = save.PlayerScore;
            FinalGameDataManager.UserHighScore = save.PlayerHighScore;
            FinalIntroDataManager.TimerTime = save.RemainingTime;
            FinalIntroDataManager.Lives = save.PlayerLives;
        }
        else{
            Debug.Log("Nothing has been saved!");
        }
    }

    public void SaveAsJSON(){
        Save save = CreateSave();
        string json = JsonUtility.ToJson(save);

        Debug.Log("Saving as JSON: " + json);
    }
}
