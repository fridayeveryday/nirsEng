
using UnityEngine;
using UnityEngine.UI;

public class ViewingMode : MonoBehaviour
{
    // Start is called before the first frame update

    public RectTransform unitOfWords;

    public RectTransform content;
    public GameManager gameMan;
    pairOfWord pOWord;

    public GameObject scrollBar;

    void Awake()
    {
        gameMan = GameManager.getInstance();
        addListofPairs();

    }

    private void Start()
    {
        //downScBar();
        //scrollBar.GetComponent<Scrollbar>().value = 0;
    }
    //void downScBar() => GameObject.Find("Scrollbar").GetComponent<Scrollbar>().value = 0.0f;
    
    private void FixedUpdate()
    {

        
        Debug.Log(GameObject.Find("Scrollbar").GetComponent<Scrollbar>().value);


    }


    void addListofPairs()
    {
        for(int i = gameMan.words.Count - 1; i >=0; i--)
        {
            GameObject newPair = Instantiate(unitOfWords.gameObject, content) as GameObject;
            inputTextIntoUnitOfWords(newPair, gameMan.words[i]);
        }

        //foreach (pairOfWord pair in gameMan.words)
        //{
            
        //    GameObject newPair = Instantiate(unitOfWords.gameObject, content) as GameObject;
        //    inputTextIntoUnitOfWords(newPair, pair);
               
        //}
        //downScBar();
    }
    bool delete = false;
    void deletePairFromUIAndDb(GameObject item)
    {
        pairOfWord pOFW;
        pOFW.word = item.transform.Find("Word").GetComponent<Text>().text;
        pOFW.translate = item.transform.Find("Translate").GetComponent<Text>().text;
        gameMan.words.Remove(pOFW);
        Destroy(item);
        delete = true;

    }

    void inputTextIntoUnitOfWords(GameObject item, pairOfWord pOfW)
    {
        item.transform.Find("Word").GetComponent<Text>().text = pOfW.word;
        item.transform.Find("Translate").GetComponent<Text>().text = pOfW.translate;
        item.transform.Find("Delete").GetComponent<Button>().onClick.AddListener(
            () =>
            {
                deletePairFromUIAndDb(item);
               // Debug.Log("one needs Delete");
            }
        );
    }


}
