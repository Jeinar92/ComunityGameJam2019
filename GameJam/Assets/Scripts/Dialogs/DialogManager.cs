using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    [SerializeField] GameObject dialogPanel;                               // Import dialog box   
    [SerializeField] GameObject liarButton;
    [SerializeField] GameObject acceptButton;
    [SerializeField] int honestNumber = 0;                                 // Number of honest NPC
    [SerializeField] DataManager getData;
    [SerializeField] IDmanager liarId;
    
    public bool open = false;                                                      // Boolean to check whether dialog box is oper
    public bool close = false;                                                     // Boolean to check whether dialog box is close
    public float id;                                                       // Boolean to check whether we are speaking to new honest NPC
    public bool talking;
   
    public bool speakinToLiar = false;
    public bool openButton = false;
    public int liarvalue = 0;
   
    void Update()
    {
        open = getData.openPanel;
        openButton = getData.openLiarButton;
        OpenPanel();
       
    }


    public void OpenPanel()
    {
        if (open == true)
        {
            if (dialogPanel != null)
            {
                dialogPanel.SetActive(true);
                acceptButton.SetActive(true);
                talking = true;
                if (openButton == true)
                {
                    acceptButton.SetActive(false);
                    liarButton.SetActive(true);
                }
                
            }

        } 

        close = true;
        
    }

    public void ClosePanel()
    {
        if (close == true)
        {
            dialogPanel.SetActive(false);
            talking = false;

            
        }
        close = false;
        
    }

    public void AcceptButton()
    {
        speakinToLiar = getData.liarSpeaking;
        if (speakinToLiar)
        {
            liarvalue++;
            speakinToLiar = false;
            
        }
        ClosePanel();

        

    }

}
