using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    [SerializeField] GameObject dialogPanel;
    [SerializeField] int actualCoinCount;
    [SerializeField] int baseCoinCount = 6;

    public bool open;
    public bool close;

    

    void Update()
    {
        OpenPanel();
    }
    public void OpenPanel()
    {
       
        if (open == true)
        {
            dialogPanel.SetActive(true);
        }
    }

    public void ClosePanel()
    {
        if (close == true)
        {
            dialogPanel.SetActive(false);
        }
        close = false;
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
            open = true;
        }
    }
    
    public void AcceptButton()
    {
        open = false;
        close = true;
        actualCoinCount = baseCoinCount + 999;
        Debug.Log(actualCoinCount);
        ClosePanel();
    }
    public void DeclineButton()
    {
        open = false;
        close = true;
        actualCoinCount = baseCoinCount;
        Debug.Log(actualCoinCount);
        ClosePanel();
    }
}
