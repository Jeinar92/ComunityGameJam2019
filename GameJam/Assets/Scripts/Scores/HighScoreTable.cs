using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScoreTable : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;
    private List<HighscoreEntry> highscoreEntryList;
    private List<Transform> highScoreEntryTransformlist;

    private void Awake()
    {
        entryContainer = transform.Find("HighScoreEntryContainer");        
        entryTemplate = entryContainer.Find("HighScoreEntryTemplate");
        
        entryTemplate.gameObject.SetActive(false);

        highscoreEntryList = new List<HighscoreEntry>()
        {
            new HighscoreEntry{score = 346725, name = "AAA"},
            new HighscoreEntry{score = 123124, name = "ANN"},
            new HighscoreEntry{score = 123455, name = "JON"},
            new HighscoreEntry{score = 124424, name = "ALE"},
            new HighscoreEntry{score = 121124, name = "LOL"},
            new HighscoreEntry{score = 335512, name = "YOU"},
            new HighscoreEntry{score = 272727, name = "DAV"},
            new HighscoreEntry{score = 224572, name = "JOR"},
            new HighscoreEntry{score = 1235582, name = "MAX"},
            new HighscoreEntry{score = 9658554, name = "CAT"},
        };
        for ( int i = 0; i < highscoreEntryList.Count; i++)
        {
            for (int j = i + 1; j < highscoreEntryList.Count; j++)
            {
                if (highscoreEntryList[j].score > highscoreEntryList[i].score)
                {
                    //swap
                    HighscoreEntry tmp = highscoreEntryList[i];
                    highscoreEntryList[i] = highscoreEntryList[j];
                    highscoreEntryList[j] = tmp;
                }
            }
        }
        highScoreEntryTransformlist = new List<Transform>();
       foreach (HighscoreEntry highscoreEntry in highscoreEntryList)
        {
            CreateHighScoreEntryTransform(highscoreEntry, entryContainer, highScoreEntryTransformlist);
        }

        HighScores highScores = new HighScores { highscoreEntryList = highscoreEntryList };
        string json = JsonUtility.ToJson(highscoreEntryList);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();
        Debug.Log(PlayerPrefs.GetString("highscoreTable"));
           
    }

    private void CreateHighScoreEntryTransform (HighscoreEntry highscoreEntry, Transform container, List<Transform> transformList
        )
    {

        float templateHeight = 35f;
        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);

        int rank = transformList.Count + 1;
        string rankString;

        switch (rank)
        {
            default:
                rankString = rank + "TH";
                break;

            case 1:
                rankString = "1ST";
                break;
            case 2:
                rankString = "2ND";
                break;
            case 3:
                rankString = "3RD";
                break;
        }
        entryTransform.Find("Ranking").GetComponent<TMP_Text>().text = rankString;

        int score = highscoreEntry.score;
        entryTransform.Find("Score").GetComponent<TMP_Text>().text = score.ToString();

        string name = highscoreEntry.name;
        entryTransform.Find("Name").GetComponent<TMP_Text>().text = name;

        transformList.Add(entryTransform);
    }

    private class HighScores
    {
        public List<HighscoreEntry> highscoreEntryList;
    }
    /*
     * Represent a single High score entry
     * */
    [System.Serializable]
    private class HighscoreEntry
    {
        public int score;
        public string name;
    } 
}

