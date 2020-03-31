using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BackButton : MonoBehaviour
{
  

    // Update is called once per frame
    void Update()
    {
        if (Application.platform == RuntimePlatform.Android 
            && SceneManager.GetActiveScene().buildIndex == (int)scenes.Menu
            && (Input.GetKey(KeyCode.Home) || Input.GetKey(KeyCode.Escape)))
        {
            Application.Quit();
            return;
        }
        else if(Application.platform == RuntimePlatform.Android 
            && (SceneManager.GetActiveScene().buildIndex == (int)scenes.PlayMode || SceneManager.GetActiveScene().buildIndex == (int)scenes.ViewingMode)
            && Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene((int)scenes.Menu);
        }
        else if(Application.platform == RuntimePlatform.Android
            && SceneManager.GetActiveScene().buildIndex == (int)scenes.AddNewPair
            && Input.GetKey(KeyCode.Escape))
        { 
            SceneManager.LoadScene((int)scenes.ViewingMode);
        }
    }
    
}


