using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Key : MonoBehaviour
{
    private string[] smallLetters;
    private string[] mediumLetters;
    private string[] largeLetters;
    private string[] allLetters;
    void Start()
    {
        string[] smallLetters = new string[] {
            "H",
            "J",
            "K",
            "L"
        };

        string[] mediumLetters = new string[]
        {
            "H",
            "J",
            "K",
            "L"
        };

        string[] largeLetters = new string[]
        {
            "F",
            "G",
            "H",
            "J",
            "K",
            "L"
        };

        string[] allLetters = new string[] {
            "B",
            "C",
            "E",
            "F",
            "G",
            "H",
            "I",
            "J",
            "K",
            "L",
            "M",
            "N",
            "O",
            "P",
            "Q",
            "R",
            "T",
            "U",
            "V",
            "X",
            "Y",
            "Z"
        };


    }

    public Key()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
