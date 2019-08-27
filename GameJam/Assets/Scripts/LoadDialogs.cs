using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadDialogs : MonoBehaviour
{
    [SerializeField] float AlterTextID;
    [SerializeField] TextMeshProUGUI textDisplay;
    [SerializeField] GameObject dialogPanel;
    [SerializeField] MovementController moveControl;

    List<Dialog> dialogArrays = new List<Dialog>();
    private string currentText = " ";
    private string dialogText;
    private bool buttonIsDonw = false;
    public bool talking = false;
    public bool close;
    
    void Start()
    {
        TextAsset dialogData = Resources.Load<TextAsset>("dialogData");
        string[] data = dialogData.text.Split(new char[] { '\n' });

        RowArrayFromData(data);
        ShowDialog();
    }

    void Update()
    {
        close = moveControl.close;
        if (close == true)
        {
            ClosePanel();
        }
    }

    public void ShowDialog()
    {
        foreach (Dialog dialog in dialogArrays)
        {
            if (dialog.child == 1)
            {
                if (dialog.id == AlterTextID)
                {
                    textDisplay.text = dialog.text;
                    dialogText = dialog.text;
                    AlterTextID += 0.01f;
                    ButtonCheck(dialog);
                }
            }
            else if(dialog.child == 2)
            {
                if (dialog.id == AlterTextID)
                {
                    textDisplay.text = dialog.text;
                    dialogText = dialog.text;
                }
            }
        }
    }
    private void ButtonCheck(Dialog dialog)
        {
            if (buttonIsDonw == true)
            {
                if (dialog.id == AlterTextID)
                {
                    textDisplay.text = dialog.text;
                    dialogText = dialog.text;
                    buttonIsDonw = false;
                }
            }
        }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            OpenPanel();
        }
    }

    private void OpenPanel()
    {
       dialogPanel.SetActive(true);      
    }

   private void ClosePanel()
    {
        dialogPanel.SetActive(false);
        close = false;
        
    }    

    private void RowArrayFromData(string[] data)
    {
        for (int i = 1; i < data.Length - 1; i++)
        {
            string[] row = data[i].Split(new char[] { ',' });

            if (row[1] != "")
            {

                Dialog dialog = new Dialog();

                int.TryParse(row[0], out dialog.id);
                int.TryParse(row[1], out dialog.Idlvl);
                int.TryParse(row[2], out dialog.NPC);
                dialog.text = row[3];
                int.TryParse(row[4], out dialog.reward);
                int.TryParse(row[5], out dialog.child);
                int.TryParse(row[6], out dialog.parentId);


                dialogArrays.Add(dialog);
            }

        }
    }
}
