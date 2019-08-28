using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    [SerializeField] GameObject dialogPanel;                               // Import dialog box   
    [SerializeField] int honestNumber = 0;                                 // Number of honest NPC
    [SerializeField] DataManager getData;
    
    public bool open = false;                                                      // Boolean to check whether dialog box is oper
    public bool close;                                                     // Boolean to check whether dialog box is close
    public bool sum;                                                       // Boolean to check whether we are speaking to new honest NPC

   
    void Update()
    {
        open = getData.openPanel;
        OpenPanel();
    }


    public void OpenPanel()
    {
        if (open == true)
        {
            dialogPanel.SetActive(true);
        }
        close = true;
    }

    public void ClosePanel()
    {
        if (close == true)
        {
            dialogPanel.SetActive(false);
        }
        close = false;
        
    }

   
    private void buttonAction()
    {
        open = false;
        close = true;
        ClosePanel();
    }


    public void AcceptButton()
    {
        buttonAction();            
    }

    public void DeclineButton()
    {
        buttonAction();
        
    }
}
