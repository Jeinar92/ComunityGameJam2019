using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    [SerializeField] MovementController moveControl;
    [SerializeField] GameObject dialogPanel;
    [SerializeField] int actualCoinCount;
    [SerializeField] int baseCoinCount = 6;

    public bool open;
    public bool close;

    

    void Update()
    {
        OpenPanel();
        ClosePanel();
    }
    private void OpenPanel()
    {
       
        if (open == true)
        {
            dialogPanel.SetActive(true);
        }
    }

    private void ClosePanel()
    {
        if (close == true)
        {
            dialogPanel.SetActive(false);
        }
        close = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<SpriteRenderer>().enabled = true;
            open = true;
            
        }
    }

    public void AcceptButton()
    {
        close = true;
        actualCoinCount = baseCoinCount + 999;
        Debug.Log(actualCoinCount);
    }
    public void DeclineButton()
    {
        close = true;
        actualCoinCount = baseCoinCount;
        Debug.Log(actualCoinCount);
    }
}
