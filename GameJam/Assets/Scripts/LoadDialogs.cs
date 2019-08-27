using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LoadDialogs : MonoBehaviour
{
    [SerializeField] float typingSpeed = 0.02f;
    [SerializeField] float AlterTextID;
    [SerializeField] TextMeshProUGUI textDisplay;
    [SerializeField] GameObject dialogPanel;

    List<Dialog> dialogArrays = new List<Dialog>();
    private string currentText = " ";
    private string dialogText;
    private bool buttonIsDonw = false;
    public bool talking;
    
    void Start()
    {
        
        TextAsset dialogData = Resources.Load<TextAsset>("dialogData");
        string[] data = dialogData.text.Split(new char[] { '\n' });

        RowArrayFromData(data);
        ShowDialog();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            talking = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            OpenPanel();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ClosePanel();
            talking = false;
        }
    }

    public void ShowDialog()
    {
        foreach (Dialog dialog in dialogArrays)
        {
            if (dialog.child == true)
            {
                if (dialog.id == AlterTextID)
                {
                    textDisplay.text = dialog.text;
                    dialogText = dialog.text;
                    AlterTextID += 0.01f;
                    ButtonCheck(dialog);
                }
            }            
        }
    }

    private void OpenPanel()
    {
       dialogPanel.SetActive(true);
      
    }

    private void ClosePanel()
    {
        dialogPanel.SetActive(false);

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

                dialogArrays.Add(dialog);
            }

        }
    }
}
