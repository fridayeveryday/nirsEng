using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public List<pairOfWord> words = new List<pairOfWord>();
    DBManager dbMan;
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
        dbMan = DBManager.getInstance();
        // dbMan = DBManager.getInstance();
        if (!dbMan)
            Debug.Log("pizzzzzdec");
        else
        {
            dbMan.connect();
            dbMan.executeData(words);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
       

        int a = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
