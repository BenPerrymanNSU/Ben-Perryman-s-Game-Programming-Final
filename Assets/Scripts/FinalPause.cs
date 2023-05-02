/*
    FinalPause.cs Controls the pause menu seen in the game scene,
    hides ui elements if pause menu is active.
*/
using UnityEngine;
using UnityEngine.UI;

public class FinalPause : MonoBehaviour
{
    public Image PauseScreen;
    public Text ScoreDisplay;
    public Text LivesDisplay;
    public Text UsernameDisplay;
    public Text CountdownDisplay;
    public Text WarningText;
    public Button ScorePlus;
    public Button ScoreMinus;
    public Button LivesPlus;
    public Button LivesMinus;
    public Button DoneButton;
    private bool Paused = false;

    void Start()
    {
        Invoke("ResumeGame", 0f);
    }

    void Update(){

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(Paused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0;
        
        Paused = true;
        PauseScreen.gameObject.SetActive(true);
        ScoreDisplay.gameObject.SetActive(false);
        ScorePlus.gameObject.SetActive(false);
        ScoreMinus.gameObject.SetActive(false);
        LivesDisplay.gameObject.SetActive(false);
        LivesPlus.gameObject.SetActive(false);
        LivesMinus.gameObject.SetActive(false);
        CountdownDisplay.gameObject.SetActive(false);
        UsernameDisplay.gameObject.SetActive(false);
        DoneButton.gameObject.SetActive(false);
        WarningText.gameObject.SetActive(false);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        
        Paused = false;
        PauseScreen.gameObject.SetActive(false);
        ScoreDisplay.gameObject.SetActive(true);
        ScorePlus.gameObject.SetActive(true);
        ScoreMinus.gameObject.SetActive(true);
        LivesDisplay.gameObject.SetActive(true);
        LivesPlus.gameObject.SetActive(true);
        LivesMinus.gameObject.SetActive(true);
        CountdownDisplay.gameObject.SetActive(true);
        UsernameDisplay.gameObject.SetActive(true);
        DoneButton.gameObject.SetActive(true);
        WarningText.gameObject.SetActive(true);
    }

}
