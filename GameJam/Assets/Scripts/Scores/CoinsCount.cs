using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinsCount : MonoBehaviour
{
    [SerializeField] int numberOfHonest = 0;
    [SerializeField] int baseCoins = 6;  
    [SerializeField] int currentCoins;

    [SerializeField] bool added = false;
    [SerializeField] bool endLvl = false;
    

    [SerializeField] int liarValue = 0;
    [SerializeField] int postLiarValue = 0;

    [SerializeField] int finalScore;
    [SerializeField] int totalScore;

    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] DialogManager liarAcept;

    public bool liarSpoken;


    private void Start()
    {
        scoreText.text = baseCoins.ToString();
    }
    private void Update()
    {       
        liarValue = liarAcept.liarvalue;
        if (added == true)
        {
            Sum();
        }
        else if ((liarValue == 0) && (endLvl))
        {
            finalScore = (6000 -( ( currentCoins * liarValue) + (numberOfHonest)) );
            totalScore = -finalScore;


        } else if ((liarValue == 1) && (endLvl))
        {
            finalScore = (  6000 -( (currentCoins * liarValue) + (numberOfHonest)));
            totalScore = -finalScore;
        }       
        
        if(liarValue == 1)
        {
            currentCoins = 6 - numberOfHonest;
            scoreText.text = currentCoins.ToString();
            postLiarValue++;
            liarSpoken = true;
            added = false;
        }
    }

    private void Sum()
    {
        currentCoins = (numberOfHonest * 1000) + (baseCoins);
        Debug.Log("Current Coins" + currentCoins);
        scoreText.text = currentCoins.ToString();
        added = false;
    }

    public void HonestSum()
    {
            baseCoins--;
            numberOfHonest++;
            added = true;        
    }
}
