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
        Debug.Log(data.Length);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
