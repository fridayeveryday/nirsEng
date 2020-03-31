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
        pairOfWord pOFW;
        pOFW.word = inFieldWord.text.ToString();
        pOFW.translate = inFieldTranslate.text.ToString();

        pOFW.word.ToLower();
        pOFW.translate.ToLower();

        pOFW.word.Trim();
        pOFW.translate.Trim();

        if (!gameMan.words.Contains(pOFW))
        {
            Error.text += pOFW.word + " " + pOFW.translate;
            gameMan.words.Add(pOFW);
            gameMan.dbMan.insertData2DB(pOFW.word, pOFW.translate);
            Error.color = new Color(155, 242, 24);
            Error.text += "Your pair was added";

        }
        else
        {
            Error.color = new Color(255, 0, 0);
            Error.text += "This word pair already exists!";
        }
        inFieldTranslate.text = "";
        inFieldWord.text = "";

    }

}
