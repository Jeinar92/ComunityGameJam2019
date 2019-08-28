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

    [SerializeField] int liarValue = 1;

    [SerializeField] int finalScore;
    [SerializeField] int totalScore;

    [SerializeField] TextMeshProUGUI scoreText;

    private void Start()
    {
        scoreText.text = baseCoins.ToString();
    }
    private void Update()
    {
        if (added == true)
        {
            currentCoins = (numberOfHonest * 1000)  + (baseCoins);
            Debug.Log("Current Coins" + currentCoins);
            scoreText.text = currentCoins.ToString();
            added = false;
           
        } else if ((liarValue == 0) && (endLvl))
        {
            finalScore = (6000 -( ( currentCoins * liarValue) + (numberOfHonest)) );
            totalScore = -finalScore;

        } else if ((liarValue == 1) && (endLvl))
        {
            finalScore = (  6000 -( (currentCoins * liarValue) + (numberOfHonest)));
            totalScore = -finalScore;
        }
        
    }
    public void HonestSum()
    {
        baseCoins--;
        numberOfHonest ++;
        added = true;
    }
    
    public void DeclinedLiar()
    {
        liarValue = 1;
    }
    public void AceptedLiar()
    {
        liarValue = 0;
    }

}
