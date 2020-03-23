using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewingMode : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private RectTransform pairOfWord;

    [SerializeField] private RectTransform content;
    GameManager gameMan;
    pairOfWord pOWord;


    private void Awake()
    {
        gameMan = GameManager.getInstance();
        addListofPairs();
    }

    void addListofPairs()
    {
        foreach (pairOfWord pair in gameMan.words)
        {
            //var instance = GameObject.Instantiate(pairOfWord.gameObject) as GameObject;
            //instance.transform.SetParent(content, false);
            GameObject newPair = GameObject.Instantiate(pairOfWord.gameObject, content) as GameObject;
            inputTextIntoPairOfWord(newPair, pair);
                //Instantiate(pairOfWord, content);

        }
    }

    void deletePairFromUIAndDb(GameObject item)
    {
        pairOfWord pOFW;
        pOFW.word = item.transform.Find("Word").GetComponent<Text>().text;
        pOFW.translate = item.transform.Find("Translate").GetComponent<Text>().text;
        gameMan.words.Remove(pOFW);
        Destroy(item);

    }

    void inputTextIntoPairOfWord(GameObject item, pairOfWord pOfW)
    {
        item.transform.Find("Word").GetComponent<Text>().text = pOfW.word;
        item.transform.Find("Translate").GetComponent<Text>().text = pOfW.translate;
        item.transform.Find("Delete").GetComponent<Button>().onClick.AddListener(
            () =>
            {
                deletePairFromUIAndDb(item);
                Debug.Log("one needs Delete");
            }
        );
    }

    void Start()
    {
        
    }

    
}
