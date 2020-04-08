using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum scenes
{
    Menu = 0,
    ViewingMode,
    AddNewPair,
    PlayMode, 
    ViewWrongs
}
public class Navigation : MonoBehaviour
{
    // scenes scenes;

   


    public void openListOfPairs() => SceneManager.LoadScene((int)scenes.ViewingMode);


    public void getBack2Menu() => SceneManager.LoadScene((int)scenes.Menu);


    public void openInputFields4NewPair() => SceneManager.LoadScene((int)scenes.AddNewPair);


    public void startLearn() => SceneManager.LoadScene((int)scenes.PlayMode);


    public void go2ViewWrongs() => SceneManager.LoadScene((int)scenes.ViewWrongs);


    public void enableOrDisablePauseInPlayProcess(GameObject pausePanel){
        if (!pausePanel.activeInHierarchy)
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0;

        }
        else
        {
            pausePanel.SetActive(false);
            Time.timeScale = 1;
        }

    }


    public void exit() => Application.Quit();
}
