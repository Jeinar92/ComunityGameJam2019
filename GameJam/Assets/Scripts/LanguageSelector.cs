using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageSelector : MonoBehaviour
{
    public int language = 0;                    // Bool that controls which languaje are we using, 0 for english --  1 for spanish


    public void SpanishButtonPressed()
    {
        language++;
    }

    private void Update()
    {
        PlayerPrefs.SetInt("language", language);
    }

}
