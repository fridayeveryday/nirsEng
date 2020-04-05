using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdderANewPair : MonoBehaviour
{

    GameManager gameMan;
    [SerializeField] InputField inFieldWord;
    [SerializeField] InputField inFieldTranslate;

    [SerializeField] Text message;
    [SerializeField] string errorStr = "that word yet exists";


    private void Awake()
    {
        gameMan = GameManager.getInstance();
    }

    public void addPair2db()
    {
        pairOfWord pOFW;
        pOFW.word = inFieldWord.text.ToString().Trim();
        pOFW.translate = inFieldTranslate.text.ToString().Trim();

        pOFW.word.ToLower();
        pOFW.translate.ToLower();

        pOFW.word.Trim();
        pOFW.translate.Trim();
        message.text = "";

        if (!gameMan.words.Contains(pOFW))
        {
            message.text += "\"" + pOFW.word + "-" + pOFW.translate + "\" ";
            gameMan.words.Add(pOFW);
            gameMan.dbMan.insertData2DB(pOFW.word, pOFW.translate);
            message.color = new Color(155, 242, 24);
            message.text += "pair was added!";
            inFieldTranslate.text = "";
            inFieldWord.text = "";

        }
        else
        {
            message.color = new Color(255, 0, 0);
            message.text += "This word pair already exists!";
        }
       

    }

}
