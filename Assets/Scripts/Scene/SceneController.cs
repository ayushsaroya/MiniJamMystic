using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    GameObject gameCanvas;
    GameObject pauseCanvas;
    private void Start()
    {
        
    }
    public void OnPlayClick()
    {
        SceneManager.LoadScene("Game");
    }

    public void OnResumeClick()
    {

    }
}
