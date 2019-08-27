using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadDialogs : MonoBehaviour
{
    [SerializeField] float typingSpeed = 0.02f;
    [SerializeField] int AlterTextID = 0;
    [SerializeField] TextMeshProUGUI textDisplay;
    List<Dialog> dialogArrays = new List<Dialog>();
    private string currentText = " ";
    
    void Start()
    {
        StartCoroutine(ShowText());
        TextAsset dialogData = Resources.Load<TextAsset>("dialogData");
        string[] data = dialogData.text.Split(new char[] { '\n' });

        RowArrayFromData(data);
        ShowDialog();
    }


    IEnumerator ShowText()
    {
        foreach (Dialog dialog in dialogArrays)
        {
            if (dialog.id == AlterTextID)
            {
                string textyText = dialog.text;
                Debug.Log(textyText);
                for (int i = 0; i < textyText.Length; i++)
                {
                    currentText = textyText.Substring(0, i);
                    textDisplay.text = currentText;
                    yield return new WaitForSeconds(typingSpeed);
                }
            }

        }
    }
    public void ShowDialog()
    {
        
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
