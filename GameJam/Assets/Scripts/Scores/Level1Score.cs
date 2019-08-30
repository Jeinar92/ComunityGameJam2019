using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Level1Score : MonoBehaviour
{
    public int lvlScore;
    public int lvlRecord;
    [SerializeField] TextMeshProUGUI lvlScoreText;
    [SerializeField] TextMeshProUGUI lvlRecordText;

    void Update()
    {
        lvlScore = PlayerPrefs.GetInt("totalScore");
        lvlRecord = PlayerPrefs.GetInt("highestScoreLvl1");

        lvlScoreText.text = "Total Lvl Score : " + lvlScore.ToString();
        lvlRecordText.text = "Level Record : " + lvlRecord.ToString();
    }
}
