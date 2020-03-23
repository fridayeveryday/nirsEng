using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DownTheScBar : MonoBehaviour
{
    [SerializeField] GameObject scrollBar;
    private void Awake()
    {
       
    }
    // Start is called before the first frame update
    void Start()
    {
        scrollBar.GetComponent<Scrollbar>().value = 0;
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
