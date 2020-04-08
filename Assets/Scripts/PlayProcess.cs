using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayProcess : MonoBehaviour
{
    GameManager gameMan;


    public Text translate;

    public Text[] answerButtonTexts = new Text[3];
    //public Button upperButton;
    //public Button middleButton;
    //public Button lowerButton;


    
    int[] wordOrder = new int[3];

    


    static string  alphabet = "abcdefghijklmnopqrstuvwxyz";
    int lenghtAlphabet = alphabet.Length;


    private void OnDisable()
    {
        Time.timeScale = 1;
    }

    /// <summary>
    /// time is 1 when we go here from a pause
    /// </summary>
    private void Awake()
    {
        
    }
    // Start is called before the first frame update

    void Start()
    {
        gameMan = GameManager.getInstance();
        gameMan.score = 0;
        gameMan.total = -1;// why -1 see to the Game Manager
        startANewPhase();
    }

    /// <summary>
    /// Choose random pair of Words from the dictionary (GameManager.words(List))
    /// </summary>
    /// <returns>random pair</returns>
    pairOfWord chooseRandomPair() => gameMan.words[Random.Range(0, gameMan.words.Count)];
   
    /// <summary>
    /// It's function of adding or removing letter "e" if word have it
    /// </summary>
    /// <param name="word"></param>
    /// <returns>The word with ot without at the end letter "e"</returns>
    string distortByAddingRemovingE(string word)
    {
        if(word[word.Length - 1] == 'e')
        {
            return word.Remove(word.Length - 1);
        }

       return word += 'e';
    }

    /// <summary>
    /// It's function replacing a random letter from alphabet 
    /// </summary>
    /// <param name="word"></param>
    /// <returns>The word with the replaced letter</returns>
    string distortByAddingRandomLetter(string word)
    {
        if(word.Length > 2)
        {
            return word.Replace(word[Random.Range(1, word.Length - 2)], alphabet[Random.Range(0, lenghtAlphabet)]);
        }
        else
        {
            return word.Replace(word[Random.Range(0, word.Length - 1)], alphabet[Random.Range(0, lenghtAlphabet)]);
        }
    }

    /// <summary>
    /// Add the right and wrong words
    /// </summary>
    /// <param name="pOfW"></param>
    /// <param name="firstDistortedWord"></param>
    /// <param name="secondDistortedWord"></param>
    void addWordsAtScene(pairOfWord rightPair, string firstDistortedWord, string secondDistortedWord)
    {
        string[] variantOfAnswer = new string[3] { rightPair.word, firstDistortedWord, secondDistortedWord };
        wordOrder = generateSequence();
        translate.text = rightPair.translate;
        for(int numOfBut = 0; numOfBut < 3; numOfBut++)
        {
            answerButtonTexts[numOfBut].text = variantOfAnswer[wordOrder[numOfBut]];
        }

    }


    /// <summary>
    /// epsilon is the smallest var for filling time bar and comparing filling degrees time bar with 1 
    /// </summary>
    float epsilon = 0.0001f;

    /// <summary>
    /// check filling the time bar
    /// </summary>
    /// <returns>true if was filled or false if wasn't filled</returns>
    bool checkIsFillTimeBar()
    {
        if (System.Math.Abs(timeBar.fillAmount - 1.0f) < epsilon)
            return true;
        return false;
    }

    /// <summary>
    /// check the time bar was filled
    /// </summary>
    private void FixedUpdate()
    {
        
        if (checkIsFillTimeBar())
        {
            startANewPhase();
        }
        
        Debug.Log(rightAndTotalScore.text.ToString());
        
    }

    /// <summary>
    /// timeBar is a image showing a stayed time
    /// </summary>
    public Image timeBar;
   
    float fillAmountIncreament = 0.01f;
    /// <summary>
    /// It's a part of UI; fill time bar that show the time to answer
    /// </summary>
    /// <returns></returns>
    IEnumerator fillTimeBar() { 
        for(float fillAmount = 0; fillAmount <= 1; fillAmount += fillAmountIncreament)
        {
            timeBar.fillAmount = fillAmount;
            yield return new WaitForSeconds(epsilon);
        }
    } 

    /// <summary>
    /// mainPair is a pair of word and its translate
    /// </summary>
    pairOfWord mainPair;
    /// <summary>
    /// wordChangedByE is a word with added letter 'e' ot removed that letter
    /// </summary>
    string wordChangedByE;
    /// <summary>
    /// wordChangedByRandomLetter is a word with a replaced random letter inside 
    /// </summary>
    string wordChangedByRandomLetter;

    /// <summary>
    /// start a new phase that is choose a new pair of words, distort english word, 
    /// add one the scene, begin time bar and show player's score
    /// </summary>
    void startANewPhase()
    {
        gameMan.total++;
        StopAllCoroutines();
        mainPair = chooseRandomPair();
        wordChangedByE = distortByAddingRemovingE(mainPair.word);
        wordChangedByRandomLetter = distortByAddingRandomLetter(mainPair.word);
        addWordsAtScene(mainPair, wordChangedByE, wordChangedByRandomLetter);
        timeBar.fillAmount = 0;
        StartCoroutine("fillTimeBar");
        displayRightAndTotalScore();
        displayRightAnswers();

    }



    public string text4CurrentResult = "Your current succes is";
    public Text scoreText;
    /// <summary>
    /// display only right answers on the game panel
    /// </summary>
    void displayRightAnswers()
    {
        scoreText.text = text4CurrentResult + " " + gameMan.score.ToString();
    }

    public string text4TotalResult = "Your current succes is ";
    public Text rightAndTotalScore;
    /// <summary>
    /// show your right answers by all loaded phase
    /// </summary>
    void displayRightAndTotalScore()
    {
        rightAndTotalScore.text = text4TotalResult + gameMan.score.ToString() + " out of " + gameMan.total.ToString();

    }

    tripleOfWords error;
    /// <summary>
    /// check a chosen answer with main pair
    /// </summary>
    /// <param name="text"></param>
    public void checkAnswer(Text text)
    {
        if (text.text == mainPair.word)
            gameMan.score++;
        else
        {
            error.translate = mainPair.translate;
            error.word = mainPair.word;
            error.wrongWord = text.text.ToString();
            gameMan.tripleWWrongs.Add(error);
        }
          
        startANewPhase();

    }

   

    /// <summary>
    /// generator of a nonrepeating sequence for placement answers
    /// </summary>
    /// <returns>int[] array of nonrepeating sequence</returns>
    int[] generateSequence()
    {
        int[] sequence = new int[3];

        sequence[0] = Random.Range(0, 3);
        //0 => 0
        if(sequence[0] == 0)
        {
            sequence[1] = Random.Range(1, 3);
            if (sequence[1] == 1)
                sequence[2] = 2;
            else
                sequence[2] = 1;

        }
        // 1 => 1
        else if(sequence[0] == 1)
        {
            sequence[1] = Random.Range(0, 3);
            if (sequence[1] == 1 || sequence[1] == 0)
            {
                if(sequence[1] == 1)
                    sequence[1]--;
                sequence[2] = 2;
            }
                
            else
                sequence[2] = 0;
        }
        //2 => 2
        else
        {
            sequence[1] = Random.Range(0, 2);
            if (sequence[1] == 0)
                sequence[2] = 1;
            else
                sequence[2] = 0;
        }
        return sequence;
    }

}
