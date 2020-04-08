
using UnityEngine;
using UnityEngine.UI;

public class ViewingWrong : MonoBehaviour
{
    // Start is called before the first frame update

    public RectTransform unitOfWords;

    public RectTransform content;
    public GameManager gameMan;
    pairOfWord pOWord;



    void Awake()
    {
        gameMan = GameManager.getInstance();
        addListofPairs();

    }

    //void downScBar() => GameObject.Find("Scrollbar").GetComponent<Scrollbar>().value = 0.0f;
    public Text emptyError;
    private void FixedUpdate()
    {
        if (gameMan.tripleWWrongs.Count == 0)
            emptyError.text = "Your error list is emprty.";
        else
            emptyError.text = "";
            
        //if (!delete)
        //    downScBar();
           

    }


    void addListofPairs()
    {
        for (int i = gameMan.tripleWWrongs.Count - 1; i >= 0; i--)
        {
            //base.addListofPairs();
            GameObject newTriple = GameObject.Instantiate(unitOfWords.gameObject, content) as GameObject;
            inputTextIntoUnitOfWords(newTriple, gameMan.tripleWWrongs[i]);
        }
        //downScBar();
        //scrollBar.GetComponent<Scrollbar>().value = 0;
        Debug.Log(GameObject.Find("Scrollbar").GetComponent<Scrollbar>().value = 0.0f);
    }
    void inputTextIntoUnitOfWords(GameObject item, tripleOfWords tripleOfWords)
    {
        item.transform.Find("Word").GetComponent<Text>().text = tripleOfWords.word;
        item.transform.Find("Translate").GetComponent<Text>().text = tripleOfWords.translate;
        item.transform.Find("WrongWord").GetComponent<Text>().text = tripleOfWords.wrongWord;

    }


   
    bool delete = false;
    //void deletePairFromUIAndDb(GameObject item)
    //{
    //    pairOfWord pOFW;
    //    pOFW.word = item.transform.Find("Word").GetComponent<Text>().text;
    //    pOFW.translate = item.transform.Find("Translate").GetComponent<Text>().text;
    //    gameMan.words.Remove(pOFW);
    //    Destroy(item);
    //    delete = true;

    //}

    //void inputTextIntoUnitOfWords(GameObject item, pairOfWord pOfW)
    //{
    //    item.transform.Find("Word").GetComponent<Text>().text = pOfW.word;
    //    item.transform.Find("Translate").GetComponent<Text>().text = pOfW.translate;
    //    item.transform.Find("Delete").GetComponent<Button>().onClick.AddListener(
    //        () =>
    //        {
    //            deletePairFromUIAndDb(item);
    //           // Debug.Log("one needs Delete");
    //        }
    //    );
    //}


}
