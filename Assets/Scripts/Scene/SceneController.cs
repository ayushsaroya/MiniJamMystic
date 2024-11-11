using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void OnPlayClick()
    {
        SoundController soundController = GameObject.FindGameObjectWithTag("SoundController").GetComponent<SoundController>();
        MusicController musicController = GameObject.FindGameObjectWithTag("MusicController").GetComponent<MusicController>();
        soundController.PlayClick();
        musicController.PlayBackgroundMusic();
        SceneManager.LoadScene("Game");
    }

    public void OnResumeClick()
    {
        GameObject gameCanvas = GameObject.FindGameObjectWithTag("GameCanvas");
        GameObject pauseCanvas = GameObject.FindGameObjectWithTag("PauseCanvas");
        SoundController soundController = GameObject.FindGameObjectWithTag("SoundController").GetComponent<SoundController>();
        foreach (Transform child in gameCanvas.transform)
        {
            child.gameObject.SetActive(true);
        }
        foreach (Transform child in pauseCanvas.transform)
        {
            child.gameObject.SetActive(false);
        }
        Time.timeScale = 1;
        soundController.PlayClick();
    }

    public void OnReturnToMainMenuClick()
    {
        SoundController soundController = GameObject.FindGameObjectWithTag("SoundController").GetComponent<SoundController>();
        MusicController musicController = GameObject.FindGameObjectWithTag("MusicController").GetComponent<MusicController>();
        soundController.PlayClick();
        musicController.PlayMainMenuMusic();
        SceneManager.LoadScene("Home");
    }

    public void OnWin()
    {
        SceneManager.LoadScene("Win");
    }
}
