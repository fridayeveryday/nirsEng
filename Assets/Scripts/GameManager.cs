using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public struct tripleOfWords
{
    public string word;
    public string translate;
    public string wrongWord;
 
}
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public List<pairOfWord> words = new List<pairOfWord>();
    public  DBManager dbMan;

    public List<tripleOfWords> tripleWWrongs = new List<tripleOfWords>();

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
            GameObject gameman = new GameObject("gameMan");
            instance = gameman.AddComponent<GameManager>();


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
        dbMan.connect();
        dbMan.executeData(words);
        int a = 0;
    }
       
    // Start is called before the first frame update
    
}
