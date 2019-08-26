using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogData : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textDisplay;
    [SerializeField] string[] sentences;
    [SerializeField] float typingSpeed;
    private int index;

    void Start()
    {
        StartCoroutine(Type());
    }
    IEnumerator Type()
    {

        foreach(char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(0.02f* typingSpeed);
        }
        
    }
    
}
