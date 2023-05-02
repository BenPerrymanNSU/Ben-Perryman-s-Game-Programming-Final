/*
    FinalGameDataManager.cs handles all data used in the game scene,
    names, lives, scores etc.
*/
using UnityEngine;
using UnityEngine.UI;

public class FinalGameDataManager : MonoBehaviour
{
    public Text ScoreDisplay;
    public Text LivesDisplay;
    public Text UsernameDisplay;
    public Text CountdownDisplay;

    public static int UserScore;
    public static int UserHighScore;
    private bool CountDownStopper = false;

    private void Start(){
        UserScore = 0;
        UserHighScore = 0;
        CountDownStopper = false;
        ScoreDisplay.text = UserScore.ToString();
        LivesDisplay.text = FinalIntroDataManager.Lives.ToString();
        UsernameDisplay.text = "Currently Playing: " + FinalIntroDataManager.UserName;
        CountdownDisplay.text = FinalIntroDataManager.TimerTime.ToString();
    }

    private void Update(){
        if (CountDownStopper == false){
            FinalIntroDataManager.TimerTime -= Time.deltaTime;
            CountdownDisplay.text = FinalIntroDataManager.TimerTime.ToString("F0");
            if (FinalIntroDataManager.TimerTime < 0){
                Debug.Log("Game Over");
                CountDownStopper = true;
            }
        }
        else{
            CountdownDisplay.text = "0";
        }

        if(UserScore > UserHighScore){
            UserHighScore = UserScore;
        }
    }

    public void FixedUpdate(){
        ScoreDisplay.text = UserScore.ToString();
        LivesDisplay.text = FinalIntroDataManager.Lives.ToString();
        UsernameDisplay.text = "Currently Playing: " + FinalIntroDataManager.UserName;
    }

    public void ScoreIncrease(){
        UserScore++;
        ScoreDisplay.text = UserScore.ToString();
    }
    
    public void ScoreDecrease(){
        if (UserScore == 0){
            UserScore = 0;
            ScoreDisplay.text = UserScore.ToString();
        }
        else{
            UserScore--;
            ScoreDisplay.text = UserScore.ToString();
        }
    }

    public void LivesIncrease(){
        FinalIntroDataManager.Lives++;
        LivesDisplay.text = FinalIntroDataManager.Lives.ToString();
    }

    public void LivesDecrease(){
        if (FinalIntroDataManager.Lives == 0){
            FinalIntroDataManager.Lives = 0;
            LivesDisplay.text = FinalIntroDataManager.Lives.ToString();
        }
        else{
            FinalIntroDataManager.Lives--;
            LivesDisplay.text = FinalIntroDataManager.Lives.ToString();
        }
    }
}
