using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] GameObject pausePanel;
    public bool paused = false;

   
    public void PauseButton()
    {
        paused = true;
        pausePanel.SetActive(true);
    }

    public void BackButton()
    {
        paused = false;
        pausePanel.SetActive(false);
    }
}
