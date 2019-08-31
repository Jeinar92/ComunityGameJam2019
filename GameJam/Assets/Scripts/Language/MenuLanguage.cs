using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuLanguage : MonoBehaviour
{
    [SerializeField] GameObject menuEN;
    [SerializeField] GameObject menuES;
    private int language;

    void Start()
    {
        language = PlayerPrefs.GetInt("language");
        if (language == 0)
        {
            menuEN.SetActive(true);
            menuES.SetActive(false);
        }
        if (language == 1)
        {
            menuEN.SetActive(false);
            menuES.SetActive(true);
        }
    }

}
