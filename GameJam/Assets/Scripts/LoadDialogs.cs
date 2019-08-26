using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadDialogs : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        TextAsset dialogs = Resources.Load<TextAsset>("dialogs");
        string[] data = dialogs.text.Split(new char[] { '\n'});
        
        for (int i = 1; i < data.Length -1; i++)
        {
            string[] row = data[i].Split(new char[] { ' ' });
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
