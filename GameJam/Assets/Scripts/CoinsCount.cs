using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
   

     void Start()
    {
       
    }

    private void Update()
    {
        if (added == true)
        {
            currentCoins = (numberOfHonest * 1000)  + (baseCoins);
            Debug.Log("Current Coins" + currentCoins);
            added = false;
           
        } else if ((liarValue == 0) && (endLvl))
        {
            finalScore =   -( ( currentCoins * liarValue) - 6000);
            totalScore = -finalScore;

        } else if ((liarValue == 1) && (endLvl))
        {
            finalScore = -((currentCoins * liarValue) - 6000);
            totalScore = -finalScore;
        }
    }
    public void HonestSum()
    {
        baseCoins--;
        numberOfHonest ++;
        added = true;
    }
    public void HonestSubstract()
    {
        numberOfHonest = 0;
    }
    public void spokeWithLiar()
    {
        liarValue = 1;
    }

}
