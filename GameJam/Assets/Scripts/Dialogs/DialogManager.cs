using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    [SerializeField] GameObject dialogPanel;                               // Import dialog box   
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
    public float id;                                                      
    public bool talking;                                                   //  Bolean to check wheter we are taling or not
    public bool liarSpoken = false;                                        // Boolean to get the import from Coins Script check whether we are speaking to new honest NPC
    public bool secondLiarTalking = false;                                 // Boolean to check if second Liar text is talking
    public int liarvalue = 0;                                              // Int to export if liar was spoken


    void Start()
    {
        LanguageSelector();
    }

    void Update()
    {
        language = PlayerPrefs.GetInt("language");
        

        liarSpoken = coins.liarSpoken;
        open = getData.openPanel;
        openLiarButton = getData.openLiarButton;
        openNormalButton = getData.openNormalButton;
        openAlterButton = getData.openAlterButton;
        openDeclineButton = getData.openDeclineButton;

        if (liarSpoken == true)
        {
            liarvalue = 0;
            //secondLiarTalking = true;
            liarSpoken = false;
            secondLiarText.SetActive(true);
        }

        OpenPanel();
    }

    private void LanguageSelector()
    {
        if (language == 0)
        {
            normalAcceptButton = GameObject.Find("Accept Normal Button");
            liarAcceptButton = GameObject.Find("Accept Liar Button");
            alterAcceptButton = GameObject.Find("Accept Alter Button");
            declineButton = GameObject.Find("Decline Button");



        }
        else if (language == 1)
        {
            normalAcceptButton = GameObject.Find("Es_AcceptNormalButton");
            liarAcceptButton = GameObject.Find("Es_AcceptLiarButton");
            alterAcceptButton = GameObject.Find("Es_AcceptAlterButton");
            declineButton = GameObject.Find("Es_Decline Button");
        }
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
        }
        else if (openNormalButton)
        {
            declineButton.SetActive(false);
            normalAcceptButton.SetActive(true);
            alterAcceptButton.SetActive(false);
            liarAcceptButton.SetActive(false);
            dialogPanel.SetActive(true);
        }
        else if (alterAcceptButton)
        {
            declineButton.SetActive(true);
            normalAcceptButton.SetActive(false);
            alterAcceptButton.SetActive(true);
            liarAcceptButton.SetActive(false);
            dialogPanel.SetActive(true);
        }
    }

    public void ClosePanel()
    {
        if (close == true)
        {

            liarAcceptButton.SetActive(false);
            alterAcceptButton.SetActive(false);
            normalAcceptButton.SetActive(false);
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
