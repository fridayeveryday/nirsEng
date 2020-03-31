using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InputAWord : MonoBehaviour
{
    public TouchScreenKeyboard keyboard;
    [SerializeField] Text inputedText;
    [SerializeField] RectTransform placeholder;
    [SerializeField] string typeInputField;

    [SerializeField] InputField inputField;



   public void openKeyboard()
   {
        TouchScreenKeyboard.hideInput = true;
        keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
        TouchScreenKeyboard.hideInput = true;

    }


    public void getInNewPair2db()
    {

    }
    
    // Start is called before the first frame update
    void Start()
    {
        TouchScreenKeyboard.hideInput = true;
    }

    
    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
        if (inputField.isFocused)
        {
            inputField.GetComponent<Image>().color = new Color(230, 255, 212);
            inputField.image.color = new Color(230, 255, 212);
        }

        if (string.IsNullOrEmpty(inputedText.text))
        {
            placeholder.GetComponent<Text>().text = "Input a " + typeInputField;
        }
        else
        {
            placeholder.GetComponent<Text>().text = "";
        }
        //inputField.selecta
        #if UNITY_ANDROID
        if(keyboard != null)
            inputedText.text = keyboard.text;
        #endif
        //if (TouchScreenKeyboard.visible == true)
        //{
           
        //    if (string.IsNullOrEmpty(keyboard.text))
        //    {
        //        placeholder.GetComponent<Text>().text = "Input a word";
        //    }
        //    else
        //    {
        //        placeholder.GetComponent<Text>().text = "";
        //        inputedText.text = keyboard.text;
        //    }  
        //}
        
        
        //inputedText.text = keyboard.text;
        //if (TouchScreenKeyboard.visible == false && keyboard != null)
        //{
            
        //    if (inputedText.text == "")
        //    {
        //        placeholder.GetComponent<Text>().text = "Input a " + typeInputField; 
        //    }


        //    if (keyboard.done)
        //    {

        //        inputedText.text = keyboard.text;
        //        Debug.Log("somethinglalal");

        //        Debug.Log(keyboard.text.ToString());
        //        //keyboard = null;
        //    }
        //}
    }
}
