using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManagerES : MonoBehaviour
{
    [SerializeField] GameObject dialogPanel;                               // Import dialog box   
    [SerializeField] GameObject UI_ES;
    [SerializeField] GameObject normalAcceptButton;                        // Import normal accept button
    [SerializeField] GameObject liarAcceptButton;                          // Import Liar accept button
    [SerializeField] GameObject alterAcceptButton;                         // Import Alter accept button
    [SerializeField] GameObject declineButton;                             // Import Decline button
    [SerializeField] GameObject secondLiarText;                            // Import 2nd Liar game object
    [SerializeField] DataManager getData;                                  // Import dataManager script
    [SerializeField] CoinsCount coins;                                     // Import cains script
    [SerializeField] int language;
    
    [SerializeField] int honestNumber = 0;                                 // Number of honest NPC spoken
    public bool open = false;                                              // Boolean to check whether dialog box is open
    public bool close = false;                                             // Boolean to check whether dialog box is close
    public bool openLiarButton = false;                                    // Boolean to check whether liar button is open
    public bool openNormalButton = false;                                  // Boolean to check whether normal button is open
    public bool openAlterButton = false;                                   // Boolean to check whether liar button is open
    public bool openDeclineButton = false;
    public bool talking;                                                   //  Bolean to check wheter we are taling or not
    public bool liarSpoken = false;                                        // Boolean to get the import from Coins Script check whether we are speaking to new honest NPC
    public bool secondLiarTalking = false;                                 // Boolean to check if second Liar text is talking
    public int liarValueES = 0;                                              // Int to export if liar was spoken


    void Update()
    {

        liarSpoken = coins.liarSpoken;
        open = getData.openPanel;
        openLiarButton = getData.openLiarButton;
        openNormalButton = getData.openNormalButton;
        openAlterButton = getData.openAlterButton;
        openDeclineButton = getData.openDeclineButton;

        if (liarSpoken == true)
        {
            liarValueES = 0;
            liarSpoken = false;
            secondLiarText.SetActive(true);
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
                ButtonActivator();
            }
        }
        close = true;
    }

    private void ButtonActivator()
    {
        if (openLiarButton)
        {
            declineButton.SetActive(true);
            normalAcceptButton.SetActive(false);
            alterAcceptButton.SetActive(false);
            liarAcceptButton.SetActive(true);
            dialogPanel.SetActive(true);
            UI_ES.SetActive(true);
        }
        else if (openNormalButton)
        {

            declineButton.SetActive(false);
            normalAcceptButton.SetActive(true);
            alterAcceptButton.SetActive(false);
            liarAcceptButton.SetActive(false);
            dialogPanel.SetActive(true);
            UI_ES.SetActive(true);

        }
        else if (alterAcceptButton)
        {
            declineButton.SetActive(true);
            normalAcceptButton.SetActive(false);
            alterAcceptButton.SetActive(true);
            liarAcceptButton.SetActive(false);
            dialogPanel.SetActive(true);
            UI_ES.SetActive(true);
        }        
    }

    public void ClosePanel()
    {
        if (close == true)
        {
            declineButton.SetActive(true);
            liarAcceptButton.SetActive(false);
            alterAcceptButton.SetActive(false);
            normalAcceptButton.SetActive(false);
            dialogPanel.SetActive(false);
            UI_ES.SetActive(false);

            talking = false;
        }
        close = false;
    }

    public void AcceptLiarButton()
    {
        liarValueES++;
        ClosePanel();
    }

}
