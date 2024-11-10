using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpellPickup : MonoBehaviour
{
    [SerializeField]
    private GameObject gameState;
    private GameState gameStateScript;

    private void Start()
    {
        gameStateScript = gameState.GetComponent<GameState>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Spell")
        {
            int currentSpells = gameStateScript.getSpellsPickedUp();
            gameStateScript.setSpellsPickedUp(currentSpells + 1);
            Destroy(collision.gameObject);
        }
    }
}
