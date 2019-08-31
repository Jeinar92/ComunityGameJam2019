using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class archivesController : MonoBehaviour
{
    [SerializeField] Canvas en_ArchivesCanvas;                                                  // Import English Archives Canvas                   
    [SerializeField] GameObject en_Archive2Active;                                                  // Import English Archive2 Active
    [SerializeField] GameObject en_Archive2Inactive;                                                // Import English Archive2 Inactive
    [SerializeField] GameObject en_Archive3Active;                                                  // Import English Archives3 Active
    [SerializeField] GameObject en_Archive3Inactive;                                                // Import English Archive3 Inactive
    [SerializeField] Canvas es_ArchivesCanvas;                                                  // Import Spanish Archives Canvas   
    [SerializeField] GameObject es_Archive2Active;                                                  // Import Spanish Archive2 Active
    [SerializeField] GameObject es_Archive2Inactive;                                                // Import Spanish Archive2 Inactive
    [SerializeField] GameObject es_Archive3Active;                                                  // Import Spanish Archive3 Active
    [SerializeField] GameObject es_Archive3Inactive;                                                // Import Spanish Archive3 Inactive

    [SerializeField] int highestScore;


    // Start is called before the first frame update
    void Start()
    {
        highestScore = PlayerPrefs.GetInt("highestScoreLvl1");

    }

    // Update is called once per frame
    void Update()
    {
        if (en_ArchivesCanvas.enabled != false)
        {
            if (highestScore == 6006)
            {
                en_Archive3Active.SetActive(true);
                en_Archive3Inactive.SetActive(false);
                en_Archive2Active.SetActive(true);
                en_Archive2Inactive.SetActive(false);

            }
            else if ((highestScore < 6006) || (highestScore >= 0))
            {
                en_Archive2Active.SetActive(true);
                en_Archive2Inactive.SetActive(false);
                en_Archive3Active.SetActive(false);
                en_Archive3Inactive.SetActive(true);

            }
        }
        else if (es_ArchivesCanvas != false)
        {
            if (highestScore == 6006)
            {
                es_Archive3Active.SetActive(true);
                es_Archive3Inactive.SetActive(false);
                es_Archive2Active.SetActive(true);
                es_Archive2Inactive.SetActive(false);

            }
            else if ((highestScore < 6006) || (highestScore >= 0))
            {
                es_Archive2Active.SetActive(true);
                es_Archive2Inactive.SetActive(false);
                es_Archive3Active.SetActive(false);
                es_Archive3Inactive.SetActive(true);

            }
        }
    }
}
