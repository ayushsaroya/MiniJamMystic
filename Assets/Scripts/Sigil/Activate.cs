using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UIElements;
using static System.Runtime.CompilerServices.RuntimeHelpers;

public class Activate : MonoBehaviour
{
    private bool colliding;
    [SerializeField]
    private GameObject comboObject;
    private float xOffset = 0.25f;
    private float yOffset = 0.5f;
    private KeyCode keyCode;
    private GameObject currentCombo;
    private float totalWidth;
    List<string> keys;
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
            if (Input.GetKey(KeyCode.Space) && transform.childCount == 0)
            {
                Debug.Log("displaying combo");
                displayCombo();
            }

            if (transform.childCount > 0)
            {
                keys = comboObject.GetComponent<Combo>().getKeys();
                if (keys.Count == 0)
                {
                    completeSigil();
                } else
                {
                    string target = keys[0];
                    if (System.Enum.TryParse(target, true, out keyCode))
                    {
                        if (Input.GetKeyDown(keyCode))
                        {
                            keys = comboObject.GetComponent<Combo>().removeKey(target);
                            hideCombo();
                            Vector3 currentComboPos = this.gameObject.transform.localPosition + new Vector3(0, yOffset, 0);
                            currentCombo = Instantiate(comboObject, currentComboPos, this.gameObject.transform.rotation, this.gameObject.transform);
                            formatKeys(currentCombo, xOffset, totalWidth, keys);
                        }
                    }
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        colliding = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        colliding = false;
        hideCombo();
    }

    private void displayCombo()
    {
        Combo combo = comboObject.GetComponent<Combo>();
        combo.generateCombo();
        
        List<string> keys = combo.getKeys();
        Vector3 currentComboPos = this.gameObject.transform.localPosition + new Vector3(0, yOffset, 0);
        currentCombo = Instantiate(comboObject, currentComboPos, this.gameObject.transform.rotation, this.gameObject.transform);
        totalWidth = (keys.Count - 1) * xOffset;
        formatKeys(currentCombo, xOffset, totalWidth, keys);
    }

    private void hideCombo()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        Combo comboScript = comboObject.GetComponent<Combo>();
        comboScript.generateCombo();
        List<string> keys = comboScript.getKeys();
    }

    private void formatKeys(GameObject currentCombo, float xOffset, float totalWidth, List<string> keys)
    {
        for (int i = 0; i < keys.Count; i++)
        {
            GameObject keyObject = currentCombo.GetComponent<Combo>().getKeyObject();
            GameObject key = Instantiate(keyObject, currentCombo.transform.transform.localPosition, currentCombo.transform.rotation, currentCombo.transform);
            float offset = -totalWidth / 2 + i * xOffset;
            key.transform.localPosition = currentCombo.transform.localPosition + new Vector3(offset, 0, 0);
            Sprite letter = Resources.Load<Sprite>("Sprites/Keys/" + keys[i]);
            if (letter != null)
            {
                key.GetComponent<SpriteRenderer>().sprite = letter;
            }
        }
    }

    private void completeSigil()
    {
        Debug.Log("completed sigil");
    }
}
