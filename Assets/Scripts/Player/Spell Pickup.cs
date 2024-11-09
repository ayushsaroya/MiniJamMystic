using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellPickup : MonoBehaviour
{
    [SerializeField]
    private GameState gameState;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Spell")
        {
            Destroy(collision.gameObject);
            gameState.setSpellsPickedUp(gameState.getSpellsPickedUp() + 1);
        }
    }
}
