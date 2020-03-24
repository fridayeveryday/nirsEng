using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum scenes
{
    Menu = 0,
    ViewingMode,
    AddNewPair
}
public class Navigation : MonoBehaviour
{
   // scenes scenes;
 

    public void openListOfPairs()
    {
        SceneManager.LoadScene((int)scenes.ViewingMode);
    }

    public void getBack2Menu()
    {
        SceneManager.LoadScene((int)scenes.Menu);
    }

    public void openInputFields4NewPair()
    {
        SceneManager.LoadScene((int)scenes.AddNewPair);
    }


}
