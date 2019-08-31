using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuLanguage : MonoBehaviour
{
    [SerializeField] Canvas EN;
    [SerializeField] Canvas ES;
    private int language;

    void Start()
    {
        language = PlayerPrefs.GetInt("language");
        if (language == 0)
        {
            EN.enabled = true;
            ES.enabled = false;
        }
        if (language == 1)
        {
            EN.enabled = false;
            ES.enabled = true;
        }
    }

}
