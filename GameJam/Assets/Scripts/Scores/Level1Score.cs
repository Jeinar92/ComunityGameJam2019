using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Level1Score : MonoBehaviour
{
    [SerializeField] Score_EverithingIsGreed everithingIsGreed;
    public int lvlCoins;
    public int lvlScore;
    [SerializeField] TextMeshProUGUI lvlCoinsText;
    [SerializeField] TextMeshProUGUI lvlScoreText;

    void Update()
    {
        lvlCoins = everithingIsGreed.currentCoins;
        lvlScore = everithingIsGreed.totalScore;

        lvlCoinsText.text = lvlCoins.ToString();
        lvlScoreText.text = lvlScore.ToString();
    }
}
