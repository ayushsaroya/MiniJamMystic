using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Activate : MonoBehaviour
{
    private bool colliding;
    [SerializeField]
    private GameObject combo;
    // Start is called before the first frame update
    void Start()
    {
        colliding = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (colliding)
        {
            displayCombo();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        colliding = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        colliding = false;
    }

    private void displayCombo()
    {
        Combo comboScript = combo.GetComponent<Combo>();
        comboScript.generateCombo();
        List<string> keys = comboScript.getKeys();
        for (int i = 0; i < keys.Count; i++)
        {
            Debug.Log(keys[i]);
        }
        for (int i = 0; i < keys.Count; i++)
        {
            GameObject key = Instantiate(combo, this.transform, true);
            Sprite letter = Resources.Load<Sprite>("Assets/Sprites/Keys/" + keys[i]);
            key.GetComponent<SpriteRenderer>().sprite = letter;
        }
        colliding = false;
    }
}
