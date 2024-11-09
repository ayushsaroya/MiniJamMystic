using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Activate : MonoBehaviour
{
    private bool colliding;
    [SerializeField]
    private GameObject comboObject;
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
        Combo combo = comboObject.GetComponent<Combo>();
        combo.generateCombo();
        List<string> keys = combo.getKeys();
        for (int i = 0; i < keys.Count; i++)
        {
            Debug.Log(keys[i]);
        }
        GameObject currentCombo = Instantiate(comboObject, this.gameObject.transform.position, this.gameObject.transform.rotation, this.gameObject.transform);
        for (int i = 0; i < keys.Count; i++)
        {
            GameObject keyObject = currentCombo.GetComponent<Combo>().getKeyObject();
            GameObject key = Instantiate(keyObject, currentCombo.transform.position, currentCombo.transform.rotation, currentCombo.transform);
            Sprite letter = Resources.Load<Sprite>("Sprites/Keys/" + keys[i] + ".png");
            if (letter != null)
            {
                Debug.Log("Not null");
                key.GetComponent<SpriteRenderer>().sprite = letter;
            }
        }
        colliding = false;
    }
}
