/*
  FinalSaveMusicSettings.cs Will keep track of the music toggle being
  checked or unchecked, will save whichever it was set to last and play
  music accordingly.
*/
using UnityEngine;
using UnityEngine.UI;

public class FinalSaveMusicSettings : MonoBehaviour
{
    public Toggle MusicTog;
    public AudioSource ToggleMusic;

    public void Awake (){
    if (!PlayerPrefs.HasKey("music")){
        PlayerPrefs.SetInt("music", 1);
        MusicTog.isOn = true;
        ToggleMusic.enabled = true;
        PlayerPrefs.Save ();
    }
    else{
        if (PlayerPrefs.GetInt ("music") == 0){
            ToggleMusic.enabled = false;
            MusicTog.isOn = false;
            }
        else{
            ToggleMusic.enabled = true;
            MusicTog.isOn = true;
        }
    }
    Invoke("MusicToggler", 0f);
  }

    public void MusicToggler(){
    if (MusicTog.isOn)
    {
      PlayerPrefs.SetInt ("music", 1);
      ToggleMusic.enabled = true;
      ToggleMusic.Play();
    }
    else
    {
      PlayerPrefs.SetInt ("music", 0);
      ToggleMusic.enabled = false;
      ToggleMusic.Stop();
    }
    PlayerPrefs.Save ();
  }

}
