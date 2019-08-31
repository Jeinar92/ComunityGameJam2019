using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score_EverithingIsGreed : MonoBehaviour
{
    [SerializeField] Canvas en_Canvas;                                                  // Import English Archives Canvas                   
    [SerializeField] Canvas es_Canvas;                                                  // Import Spanish Archives Canvas   
    [SerializeField] GameObject es_Ending1;
    [SerializeField] GameObject es_Ending2;
    [SerializeField] GameObject es_Ending3;
    [SerializeField] GameObject en_Ending1;
    [SerializeField] GameObject en_Ending2;
    [SerializeField] GameObject en_Ending3;

    public int currentCoins;
    public int totalScore;


    void Start()
    {
        currentCoins = PlayerPrefs.GetInt("currentCoins");
        totalScore = PlayerPrefs.GetInt("totalScore");
    }

    void Update()
    {
        if (en_Canvas.enabled != false)
        {
            if (totalScore == 6006)
            {
                en_Ending3.SetActive(true);
                en_Ending2.SetActive(false);
                en_Ending1.SetActive(false);
            }
            else if ((totalScore < 6006) && (totalScore > 0))
            {
                en_Ending3.SetActive(false);
                en_Ending2.SetActive(true);
                en_Ending1.SetActive(false);
            }
            else if (totalScore == 0)
            {
                en_Ending3.SetActive(false);
                en_Ending2.SetActive(false);
                en_Ending1.SetActive(true);
            }


        }
        else if (es_Canvas.enabled != false)
        {
            if (totalScore == 6006)
            {
                es_Ending3.SetActive(true);
                es_Ending2.SetActive(false);
                es_Ending1.SetActive(false);
            }
            else if ((totalScore < 6006) && (totalScore > 0))
            {
                es_Ending3.SetActive(false);
                es_Ending2.SetActive(true);
                es_Ending1.SetActive(false);
            }
            else if(totalScore == 0)
            {
                es_Ending3.SetActive(false);
                es_Ending2.SetActive(false);
                es_Ending1.SetActive(true);
            }
        }
    }

}