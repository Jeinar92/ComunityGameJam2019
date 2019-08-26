using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadDialogs : MonoBehaviour
{

    List<Dialog> dialogArrays = new List<Dialog>();
    
    void Start()
    {
        TextAsset dialogData = Resources.Load<TextAsset>("dialogData");

        string[] data = dialogData.text.Split(new char[] { '\n' });

        for (int i = 1; i < data.Length - 1; i++)
        {
            string[] row = data[i].Split(new char[] { ',' });

            if (row[1] != "") {

                Dialog dialog = new Dialog();

                int.TryParse(row[0], out dialog.id);
                int.TryParse(row[1], out dialog.Idlvl);
                int.TryParse(row[2], out dialog.NPC);
                dialog.text = row[3];
                int.TryParse(row[4], out dialog.reward);

                dialogArrays.Add(dialog);
            }
            
        }

        foreach (Dialog dialog in dialogArrays)
        {
            Debug.Log(dialog.text);
        }

    }

}
