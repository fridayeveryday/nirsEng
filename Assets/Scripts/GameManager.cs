using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    List<pairOfWord> words = new List<pairOfWord>();
    DBManager dbMan;
    static GameManager getInstance()
    {
        if (!instance)
            instance = new GameManager();
        return instance;
    }



    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
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

        int a = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
