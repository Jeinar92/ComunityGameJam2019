using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public float newAlterId;
    public bool changePanel = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "AlterEgo")
        {
            IDGetter(collision);
        }
    }

    void IDGetter(Collider2D collision)
    {
        collision.gameObject.name = "Alter_01";
            Debug.Log("toma");
            GameObject go = GameObject.Find("Alter_01");
            IDmanager manager = go.GetComponent<IDmanager>();
            newAlterId = manager.alterID;
        if (newAlterId == manager.alterID)
        {
            changePanel = true;
            Debug.Log(newAlterId);
            collision.gameObject.name = "AlterUsado";
        }
    }
    
}
