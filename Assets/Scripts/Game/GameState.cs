using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameState : MonoBehaviour
{
    [SerializeField]
    private GameObject spell;
    private int spellsPickedUp;
    [SerializeField]
    private TMP_Text spellsCollected;
    // Start is called before the first frame update
    void Start()
    {
        spellsPickedUp = 0;
        startSpellSpawner(5f);
    }

    public int getSpellsPickedUp()
    {
        return spellsPickedUp;
    }

    public void setSpellsPickedUp(int spells)
    {
        spellsPickedUp = spells;
        spellsCollected.text = getSpellsPickedUp() + " Spells Collected";
        Debug.Log("spellsPickedUp is now: " + spellsPickedUp);
    }

    private void startSpellSpawner(float delay)
    {
        StartCoroutine(spawnSpell(delay));
    }

    IEnumerator spawnSpell(float delay)
    {
        float leftEdge = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane)).x;
        float rightEdge = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, Camera.main.nearClipPlane)).x;
        float randomX = Random.Range(leftEdge, rightEdge);

        float bottomEdge = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane)).y;
        float topEdge = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, Camera.main.nearClipPlane)).y;
        float randomY = Random.Range(bottomEdge, topEdge);

        Vector3 spellPos = new Vector3(randomX, randomY, 0);
        Instantiate(spell, spellPos, Quaternion.identity);
        yield return new WaitForSeconds(delay);
        StartCoroutine(spawnSpell(delay));

    }
}
