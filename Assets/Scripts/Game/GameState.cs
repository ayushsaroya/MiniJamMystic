using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    private int spellsPickedUp;
    // Start is called before the first frame update
    void Start()
    {
        spellsPickedUp = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int getSpellsPickedUp()
    {
        return spellsPickedUp;
    }

    public void setSpellsPickedUp(int spellsPickedUp)
    {
        this.spellsPickedUp = spellsPickedUp;
    }
}
