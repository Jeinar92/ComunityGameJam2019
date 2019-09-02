using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadDialogs : MonoBehaviour
{
    [SerializeField] float alterTextID;                                      // float with id to get from alter on collision
    [SerializeField] float liarTextID;                                       // float with id to get from liar on collision
    [SerializeField] float normalTextID;                                     // float with id to get from normal on collision
    [SerializeField] float actualIDText;                                     // float with id to store actual ID displaying
    [SerializeField] int language;                                           // int to save languaje selected
    [SerializeField] TextMeshProUGUI textDisplay;                            // Variable to change or text on screen
    [SerializeField] DataManager getData;                                    // Importing DataManager script
        
    [SerializeField] bool openAlterButton;                                   //bool import to know wheter alter accept button is open or not
    [SerializeField] bool openNormalButton;                                  //bool import to know wheter normal accept button is open or not
    [SerializeField] bool openLiarButton;                                    //bool import to know wheter liar accept button is open or not

    List<Dialog> dialogArrays = new List<Dialog>();
    public bool panel = false;
   // public bool liarpanel = false;

    void Update()
    {
        liarTextID = getData.newLiarId;
        alterTextID = getData.newAlterId;
        normalTextID = getData.newNormalId;

        panel = getData.changePanel;

        openNormalButton = getData.openNormalButton;
        openAlterButton = getData.openAlterButton;
        openLiarButton = getData.openLiarButton;

        if (openAlterButton)
        {
            actualIDText = alterTextID;
        }
        else if (openLiarButton)
        {
            actualIDText = liarTextID;
        }
        else if (openNormalButton)
        {
            actualIDText = normalTextID;
        }
        ShowDialog();
    }

    void Start()
    {
        language = PlayerPrefs.GetInt("language");

        if (language == 0)
        {
            TextAsset dialogData = Resources.Load<TextAsset>("dialogData");
            string[] data = dialogData.text.Split(new char[] { '\n' });

            RowArrayFromData(data);
        }
        if (language == 1)
        {
            TextAsset dialogData = Resources.Load<TextAsset>("dialogDataES");
            string[] data = dialogData.text.Split(new char[] { '\n' });

            RowArrayFromData(data);
        }
        
        
    }

    public void ShowDialog()
    {
        if (panel)
        {
            foreach (Dialog dialog in dialogArrays)
            {
                if (dialog.id == actualIDText)
                {
                    textDisplay.text = dialog.text;
                }
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

                dialogArrays.Add(dialog);
            }

        }
    }
}
