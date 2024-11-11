using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private SoundController soundController;
    private void Start()
    {
        soundController = GameObject.FindGameObjectWithTag("SoundController").GetComponent<SoundController>();
    }
    public void OnPlayClick()
    {
        SceneManager.LoadScene("Game");
    }

    public void OnResumeClick()
    {
        GameObject gameCanvas = GameObject.FindGameObjectWithTag("GameCanvas");
        GameObject pauseCanvas = GameObject.FindGameObjectWithTag("PauseCanvas");
        foreach (Transform child in gameCanvas.transform)
        {
            child.gameObject.SetActive(true);
        }
        foreach (Transform child in pauseCanvas.transform)
        {
            child.gameObject.SetActive(false);
        }
        Time.timeScale = 1;
    }

    public void OnReturnToMainMenuClick()
    {
        SceneManager.LoadScene("Home");
    }

    public void OnWin()
    {
        SceneManager.LoadScene("Win");
    }
}
