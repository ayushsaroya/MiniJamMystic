using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{
    [SerializeField]
    private GameObject spell;
    private int spellsPickedUp;
    [SerializeField]
    private TMP_Text spellsCollected;
    private int lives;
    private float time;
    [SerializeField]
    private TMP_Text timeText;
    private int seconds;
    private string difficulty;
    private float spellDelay;
    private int sigilCount;
    [SerializeField]
    private GameObject sigil;
    private int sigilRadius;
    private GameObject[] sigils;
    GameObject gameCanvas;
    GameObject pauseCanvas;
    [SerializeField]
    private SceneController sceneController;
    // Start is called before the first frame update
    void Start()
    {
        spellsPickedUp = 0;
        lives = 3;
        spellDelay = 5f;
        sigilCount = 1;
        sigilRadius = 3;
        StartCoroutine(spawnSpell(spellDelay));
        time = 0;
        seconds = 0;
        difficulty = Combo.DIFFICULTY_EASY;
        gameCanvas = GameObject.FindGameObjectWithTag("GameCanvas");
        pauseCanvas = GameObject.FindGameObjectWithTag("PauseCanvas");
    }

    private void Update()
    {
        time += Time.deltaTime;
        if (time >= 1f)
        {
            seconds++;
            timeText.text = seconds + "";
            time = 0f;
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            foreach (Transform child in gameCanvas.transform)
            {
                child.gameObject.SetActive(false);
            }
            foreach (Transform child in pauseCanvas.transform)
            {
                child.gameObject.SetActive(true);
            }
            Time.timeScale = 0;
        }

        if (lives <= 0)
        {
            SceneManager.LoadScene("Lose");
        }

        if (difficulty == Combo.DIFFICULTY_EASY && seconds >= 15)
        {
            difficulty = Combo.DIFFICULTY_MEDIUM;
        } else if (difficulty == Combo.DIFFICULTY_MEDIUM && seconds >= 30)
        {
            difficulty = Combo.DIFFICULTY_HARD;
        } else if (difficulty ==Combo.DIFFICULTY_HARD && seconds >= 60)
        {
            difficulty = Combo.DIFFICULTY_MYSTIC;
        }

        sigils = GameObject.FindGameObjectsWithTag("Sigil");
        bool sigilRemaining = false;
        foreach (GameObject sigil in sigils) { 
            if (!sigil.GetComponent<Activate>().getCompleted())
            {
                sigilRemaining = true;
            }
        }
        if (!sigilRemaining && sigils.Length > 0)
        {
            if (sigilCount >= 9)
            {
                sceneController.OnWin();
            }
            sigilCount += 2;
            spawnSigils();
        }
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
    public int getSpellsPickedUp()
    {
        return spellsPickedUp;
    }

    public void setSpellsPickedUp(int spells)
    {
        spellsPickedUp = spells;
        spellsCollected.text = getSpellsPickedUp() + "";
    }

    public int getLives()
    {
        return lives;
    }

    public void setLives(int lives)
    {
        this.lives = lives;
    }

    public string getDifficulty()
    {
        return difficulty;
    }

    public void setDifficulty(string difficulty)
    {
        this.difficulty = difficulty;
    }

    public void spawnSigils()
    {
        for (int i = 0; i < sigilCount; i++)
        {
            float angle = i * Mathf.PI * 2 / sigilCount;

            float x = Mathf.Cos(angle) * sigilRadius;
            float y = Mathf.Sin(angle) * sigilRadius;

            Vector3 sigilPosition = new Vector3(x, y, 0) + transform.position;

            GameObject newSigil = Instantiate(sigil, sigilPosition, Quaternion.identity);
            int random = Random.Range(1, 5);
            Sprite sigilSprite = Resources.Load<Sprite>("Sprites/Sygil/complete_sygil" + random);
            newSigil.GetComponent<SpriteRenderer>().sprite = sigilSprite;
        }
    }
}
