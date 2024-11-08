using System.Collections;
using System.Collections.Generic;
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
        
    }
}
