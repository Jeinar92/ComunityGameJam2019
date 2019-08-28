using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    [SerializeField] GameObject dialogPanel;                               // Import dialog box   
    [SerializeField] GameObject liarButton;                                // Import Liar accept button
    [SerializeField] GameObject acceptButton;                              // Import Alter accept button
    [SerializeField] DataManager getData;                                  // Import dataManager
    [SerializeField] CoinsCount coins;

    [SerializeField] int honestNumber = 0;                                 // Number of honest NPC spoken
    public bool open = false;                                              // Boolean to check whether dialog box is open
    public bool close = false;                                             // Boolean to check whether dialog box is close
    public bool openLiarButton = false;                                    // Boolean to check whether liar button is open
    public float id;                                                      
    public bool talking;                                                    // Boolean to check whether we are speaking to new honest NPC
    public bool liarSpoken = false;

    public int liarvalue = 0;
   
    void Update()
    {
        liarSpoken = coins.liarSpoken;
        open = getData.openPanel;
        openLiarButton = getData.openLiarButton;

        if(liarSpoken == true)
        {
            liarvalue--;
        }
        OpenPanel();
    }


    public void OpenPanel()
    {
        if (open == true)
        {
            talking = true;

            if (dialogPanel != null)
            {
                LiarButtonCheck();
            }
        } 
        close = true;        
    }

    private void LiarButtonCheck()
    {
        if (openLiarButton == true)
        {
            acceptButton.SetActive(false);
            liarButton.SetActive(true);
            dialogPanel.SetActive(true);
        }
        else
        {
            dialogPanel.SetActive(true);
        }
    }

    public void ClosePanel()
    {
        if (close == true)
        {
            liarButton.SetActive(false);
            acceptButton.SetActive(true);
            dialogPanel.SetActive(false);
            talking = false;
        }
        close = false;        
    }

    public void AcceptLiarButton()
    {
        liarvalue++;   
        ClosePanel();
    }

}
