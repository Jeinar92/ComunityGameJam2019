using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILanguageController : MonoBehaviour
{
    private int language;
    [SerializeField] DialogManager dialogManagerEN;
    [SerializeField] DialogManagerES dialogManagerES;

    void Start()
    {
       language = PlayerPrefs.GetInt("language");
    }

    void Update()
    {
        if (language == 0)
        {
            dialogManagerEN.enabled = true;
            dialogManagerES.enabled = false;
        }
        if (language == 1)
        {
            dialogManagerEN.enabled = false;
            dialogManagerES.enabled = true;

        }
    }

}
