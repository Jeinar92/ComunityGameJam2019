using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinsCount : MonoBehaviour
{
    [SerializeField] int alterAccepted = 0;                                //Total number of Alter acepted
    [SerializeField] int afterLiar_AlterAccepted = 0;                                //Current number of Alter acepted
    [SerializeField] int baseCoins = 6;                                     //Coins given at start
    [SerializeField] int currentCoins;                                      // Coins updated in base to base coins and number of alter acepted

    [SerializeField] bool added = false;                                    // Bool to control if an alter was acepted
    [SerializeField] bool endLvl = false;                                   // Bool to control if we reached the end of level
    

    [SerializeField] int liarValue = 0;                                     // Its value is 1 if Liar is acepted and 0 if not or not spoken
    [SerializeField] int postLiarValue = 0;                                 // int to save liar value before it gets reset

    [SerializeField] int finalScore;                                        // int where we save formula of final score of the level
    [SerializeField] int totalScore;                                        // - finalscore

    [SerializeField] TextMeshProUGUI scoreText;                             // TMpro import for changing scoreText
    [SerializeField] DialogManager liarAcept;                               // Import script DialogManager to get info from it

    public bool liarSpoken;                                                 // Bool to export if liar was spoken after changing scoreText


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
            finalScore = (6000 - ((currentCoins * liarValue) + (alterAccepted)));
            totalScore = -finalScore;


        }
        else if ((liarValue == 1) && (endLvl))
        {
            finalScore = (6000 - ((currentCoins * liarValue) + (alterAccepted)));
            totalScore = -finalScore;
        }

        LiarValueCheck();
    }

    private void LiarValueCheck()
    {
        if (liarValue == 1)
        {
            currentCoins = 6 - alterAccepted;
            scoreText.text = currentCoins.ToString();
            postLiarValue++;
            liarSpoken = true;
            added = false;
        }
    }

    private void Sum()
    {
        if (!liarSpoken)
        {   currentCoins = (alterAccepted * 1000) + (baseCoins);
            Debug.Log("Current Coins" + currentCoins);
            scoreText.text = currentCoins.ToString();
            added = false;
        }
        else
        {
            currentCoins = (afterLiar_AlterAccepted * 1000) + baseCoins;
            Debug.Log("Current Coins" + currentCoins);
            scoreText.text = currentCoins.ToString();
            added = false;

        }
        
    }

    public void HonestSum()
    {
        baseCoins--;
        alterAccepted++;
        added = true;

        if (liarSpoken)
        {
            afterLiar_AlterAccepted++;
        }
    }
}
