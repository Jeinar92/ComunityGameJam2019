using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{
   

    public void BackButton()
    {
        SceneManager.LoadScene(1);
    }

    public void ArchivesButton()
    {
        SceneManager.LoadScene(2);
    }

    public void CreditButton()
    {
        SceneManager.LoadScene(3);
    }

    public void ScoresButton()
    {
        SceneManager.LoadScene(4);
    }
    public void PlayButton()
    {
        SceneManager.LoadScene(5);
    }



}
