using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public List<pairOfWord> words = new List<pairOfWord>();
    public  DBManager dbMan;



    /// <summary>
    /// show right answers
    /// </summary>
    public  int score = 0;

    /// <summary>
    /// show total answers (right and wrong). One equals -1 because the first load pair of words is without any attempt to answer. 
    /// So when one will be loaded total will equals 0 and after the next answer or missing attempt to answer.
    /// </summary>
    public int total = -1;

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
