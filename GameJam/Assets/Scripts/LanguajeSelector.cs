using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguajeSelector : MonoBehaviour
{
    public int languaje = 0;                    // Bool that controls which languaje are we using, 0 for english --  1 for spanish


    public void SpanishButtonPressed()
    {
        languaje++;
    }

    private void Update()
    {
        PlayerPrefs.SetInt("languaje", languaje);
    }

}
