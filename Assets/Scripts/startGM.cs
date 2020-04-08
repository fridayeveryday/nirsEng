using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startGM : MonoBehaviour
{
    private void Awake()
    {
        GameManager.getInstance();
    }
}
