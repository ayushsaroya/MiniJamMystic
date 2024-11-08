using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combo : MonoBehaviour
{
    private List<GameObject> keys;
    private string[] smallLetters;
    private string[] mediumLetters;
    private string[] largeLetters;
    private string[] allLetters;
    private string[] keySet;
    private string difficulty;
    // Start is called before the first frame update
    void Start()
    {
        // Easy => smallLetters
        // Medium => mediumLetters
        // Hard => hardLetters
        // Mystic => allLetters
        difficulty = "Easy";
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

        if (difficulty == "Easy")
        {
            keySet = smallLetters;
        }
        else if (difficulty == "Medium")
        {
            keySet = mediumLetters;
        }
        else if (difficulty == "Hard")
        {
            keySet = largeLetters;
        }
        else if (difficulty == "Mystic")
        {

        }

        keys = new List<GameObject>();
        for (int i = 0; i < 5; i++)
        {
            Key key = new Key();
            keys.Add(new );
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
