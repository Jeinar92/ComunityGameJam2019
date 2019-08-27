using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsCount : MonoBehaviour
{
    [SerializeField] int numberOfHonest = 0;
    [SerializeField] int numberOfCoins;
    [SerializeField] int currentCoins;
    [SerializeField] bool added = false;

     void Start()
    {
        currentCoins = (numberOfHonest * 1000 )- (numberOfHonest -1) ;
        Debug.Log(numberOfHonest);
    }

    private void Update()
    {
        if (added == true)
        {
            Debug.Log("Current Coins" + currentCoins);
            added = false;
        }
        numberOfCoins = numberOfHonest;
    }
    public void HonestSum()
    {
        numberOfHonest ++;
        added = true;
        Debug.Log(numberOfHonest);
    }
    public void HonestSubstract()
    {
        numberOfHonest --;
        
        Debug.Log(numberOfHonest);
    }


}
