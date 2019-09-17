using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CoinsCount : MonoBehaviour
{
    [SerializeField] int alterAccepted = 0;                                 //Total number of Alter acepted
    [SerializeField] int afterLiar_AlterAccepted = 0;                       //Current number of Alter acepted
    [SerializeField] int baseCoins = 6;                                     //Coins given at start
    [SerializeField] int currentCoins;                                      // Coins updated in base to base coins and number of alter acepted
    [SerializeField] int totalAlterAccepted;

    [SerializeField] bool added = false;                                    // Bool to control if an alter was acepted
    [SerializeField] bool endLvl = false;                                   // Bool to control if we reached the end of level

    [SerializeField] int liarValueES = 0;
    [SerializeField] int liarValue = 0;                                     // Its value is 1 if Liar is acepted and 0 if not or not spoken
    [SerializeField] int liarScore;
    [SerializeField] int finalScore;                                       // int where we save formula of final score of the level
    [SerializeField] int totalScore;                                    // negative finalscore saved on a string
    [SerializeField] int highestScore;                                     // int where we save the highest Score obtained                               
    [SerializeField] int maxScore;


    [SerializeField] TextMeshProUGUI scoreText;                             // TMpro import for changing scoreText
    [SerializeField] DialogManager liarAcept;                               // Import script DialogManager to get info from it
    [SerializeField] DataManager data;                                      // Import script DataManager to get info from it
    [SerializeField] DialogManagerES liarAceptES;
    [SerializeField] AudioSource coinSound;                                 // Import coin gain sound;
    public bool liarSpoken = false;                                                 // Bool to export if liar was spoken after changing scoreText
    private int language;

    private void Start()
    {
        scoreText.text = baseCoins.ToString();
        highestScore = 0;
    }
    private void Update()
    {
        endLvl = data.goal;
        language = PlayerPrefs.GetInt("language");
        
        if (language == 0)
        {
            liarValue = liarAcept.liarvalue;
        } else if (language == 1)
        {

            liarValue = liarAceptES.liarValueES;
        }
           
        
        if (added == true)
        {
            Sum();
        }

        FinalScore();
        LiarValueCheck();
    }

    private void FinalScore()
    {
        if (endLvl)
        {
            totalAlterAccepted = alterAccepted + afterLiar_AlterAccepted;
            if ((currentCoins == 6) && (liarSpoken == true))
            {
                totalScore = 6006;
            }else if (currentCoins == 0){

                totalScore = 0;
            }
            else
            {
                maxScore = 6006;
                totalScore = maxScore - currentCoins;

            }


            Debug.Log("Total Score : " + totalScore);

            PlayerPrefs.SetInt("totalScore", totalScore);

            if ((totalScore) > highestScore)
            {
                highestScore = totalScore;
                PlayerPrefs.SetInt("highestScoreLvl1", highestScore);
                Debug.Log("New record : " + highestScore);
            }
            PlayerPrefs.SetInt("currentCoins", currentCoins);
            SceneManager.LoadScene(6);
        }
    }

    private void LiarValueCheck()
    {
        if (liarValue == 1)
        {
            currentCoins = 6 - alterAccepted;
            scoreText.text = currentCoins.ToString();
          //  postLiarValue++;
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
        coinSound.Play();

        if (liarSpoken)
        {
            afterLiar_AlterAccepted++;
            coinSound.Play();
        }
    }
}
