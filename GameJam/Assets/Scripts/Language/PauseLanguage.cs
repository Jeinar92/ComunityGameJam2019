using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseLanguage : MonoBehaviour
{
    private int language;
    [SerializeField] GameObject pauseEN;
    [SerializeField] GameObject pauseES;

    void Start()
    {
        language = PlayerPrefs.GetInt("language");
    }

    void Update()
    {
        if (language == 0)
        {
            pauseEN.SetActive(true);
            pauseES.SetActive(false);
        }
        if (language == 1)
        {
            pauseEN.SetActive(false);
            pauseES.SetActive(true);

        }
    }
}
