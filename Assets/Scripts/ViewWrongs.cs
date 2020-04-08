using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewWrongs : MonoBehaviour
{
    // Start is called before the first frame update
    tripleOfWords tripleOfWords;
    public RectTransform unitOfWords;

    public RectTransform content;
    public GameManager gameMan;

    public GameObject scrollBar;
    void Awake()
    {
        gameMan = GameManager.getInstance();
       if(gameMan.tripleWWrongs.Count != 0)
        {
            addListofPairs();
            isLoaded = true;
        }
    }

    void downScBar() => GameObject.Find("Scrollbar").GetComponent<Scrollbar>().value = 0.0f;

    bool isLoaded = false;
    private void FixedUpdate()
    {
        //scrollBar.GetComponent<Scrollbar>().value = 0;

        
            

        //if (isLoaded)
        //{
        //    downScBar();
        //    isLoaded = false;
        //}

        Debug.Log(GameObject.Find("Scrollbar").GetComponent<Scrollbar>().value);


    }
    void addListofPairs()
    {
        foreach (tripleOfWords tripleOfWords in gameMan.tripleWWrongs)
        {
            //base.addListofPairs();
            GameObject newTriple = GameObject.Instantiate(unitOfWords.gameObject, content) as GameObject;
            inputTextIntoUnitOfWords(newTriple, tripleOfWords);
        }
        downScBar();
        scrollBar.GetComponent<Scrollbar>().value = 0;
        Debug.Log(GameObject.Find("Scrollbar").GetComponent<Scrollbar>().value = 0.0f);
    }
    void inputTextIntoUnitOfWords(GameObject item, tripleOfWords tripleOfWords)
    {
        item.transform.Find("Word").GetComponent<Text>().text = tripleOfWords.word;
        item.transform.Find("Translate").GetComponent<Text>().text = tripleOfWords.translate;
        item.transform.Find("WrongWord").GetComponent<Text>().text = tripleOfWords.wrongWord;

    }

  
}
