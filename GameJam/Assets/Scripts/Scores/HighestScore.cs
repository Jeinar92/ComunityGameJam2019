using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighestScore : MonoBehaviour
{
    public int highestScoreLvl1;
    [SerializeField] TextMeshProUGUI scoreLvl1Text;
    
    
    void Update()
    {
        highestScoreLvl1 = PlayerPrefs.GetInt("highestScoreLvl1");
        scoreLvl1Text.text = highestScoreLvl1.ToString();
    }
}
