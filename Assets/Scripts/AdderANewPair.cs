using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdderANewPair : MonoBehaviour
{

    GameManager gameMan;
    [SerializeField] InputField inFieldWord;
    [SerializeField] InputField inFieldTranslate;

    [SerializeField] Text Error;
    [SerializeField] string errorStr = "that word yet exists";


    private void Awake()
    {
        gameMan = GameManager.getInstance();
    }

    public void addPair2db()
    {
        if(!gameMan.dbMan.insertData2DB(inFieldWord.text, inFieldTranslate.text))
        {
            Error.text = errorStr;
        }
       // inFieldWord.text
    }

}
