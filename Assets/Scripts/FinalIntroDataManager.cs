/*
    FinalIntroDataManager.cs saves all data associated
    with intro menu objects: Lives, Countdown timer, Name.
*/
using UnityEngine;
using UnityEngine.UI;

public class FinalIntroDataManager : MonoBehaviour
{
    public Slider CountdownSlider;
    public Dropdown LivesDropdown;
    public InputField UserInput;

    public static int Lives = 1;
    public static float TimerTime = 30f;
    public static string UserName = "PlayerName";

    public void Start(){
        TimerTime = 30f;
        UserName = "PlayerName";
        Lives = 1;
    }

    public void CountdownTimerChanger(){
        TimerTime = CountdownSlider.value;
    }

    public void LivesSelectionDropDown(){
        Lives = LivesDropdown.value;
    }

    public void SaveUserName(){
		UserName = UserInput.text.ToString();
	}
}
