﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageSelector : MonoBehaviour
{
    public int language;                    // Bool that controls which languaje are we using, 0 for english --  1 for spanish

    private void Start()
    {
        PlayerPrefs.DeleteKey("languaje");
    }

    public void EnglishButtonPressed()
    {
        language = 0;
        PlayerPrefs.SetInt("language", language);
    }
    public void SpanishButtonPressed()
    {
        language++;
        PlayerPrefs.SetInt("language", language);
    }


}
