using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public List<pairOfWord> words = new List<pairOfWord>();
    public  DBManager dbMan;


    public void getAndPasteNewPair(string word, string translate)
    {
        dbMan.insertData2DB(word, translate);
    }

    public static GameManager getInstance()
    {
        if (!instance)
        {
            GameObject gameMan = new GameObject("gameMan");
            instance = gameMan.AddComponent<GameManager>();


        }
            //instance = new GameManager();
        return instance;
    }


  
    private void Awake()
    {
        if (!instance)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }



        dbMan = DBManager.getInstance();
        // dbMan = DBManager.getInstance();
        if (!dbMan) { }
        //Debug.Log("pizzzzzdec");
        else
        {
            dbMan.connect();
            dbMan.executeData(words);
        }
    }
    // Start is called before the first frame update
    
}
