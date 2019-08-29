using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadDialogs : MonoBehaviour
{
    [SerializeField] float alterTextID;
    [SerializeField] float liarTextID;
    [SerializeField] float normalTextID;
    [SerializeField] float actualIDText;

    [SerializeField] TextMeshProUGUI textDisplay;
    [SerializeField] DataManager getData;

    [SerializeField] bool openAlterButton;
    [SerializeField] bool openNormalButton;
    [SerializeField] bool openLiarButton;

    List<Dialog> dialogArrays = new List<Dialog>();
    public bool panel = false;
    public bool liarpanel = false;

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
        TextAsset dialogData = Resources.Load<TextAsset>("dialogData");
        string[] data = dialogData.text.Split(new char[] { '\n' });

        RowArrayFromData(data);
        
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
                int.TryParse(row[4], out dialog.reward);

                dialogArrays.Add(dialog);
            }

        }
    }
}
