using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuLanguage : MonoBehaviour
{
    [SerializeField] GameObject EN;
    [SerializeField] GameObject ES;
    private int language;

    void Start()
    {
        language = PlayerPrefs.GetInt("language");
        if (language == 0)
        {
            EN.SetActive(true);
            ES.SetActive(false);
        }
        if (language == 1)
        {
            EN.SetActive(false);
            ES.SetActive(true);
        }
    }

}
