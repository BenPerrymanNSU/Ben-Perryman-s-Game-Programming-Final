/*
    FinalButtonManager.cs adds functionality to all buttons,
    moving to the next scene, returning to scene 0, and exiting
    the game window or application.
*/
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalButtonManager : MonoBehaviour
{
    public void ToNextGameScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ReturnToIntro(){
        SceneManager.LoadScene(0);
    }

    public void ExitPlayWindow(){
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
