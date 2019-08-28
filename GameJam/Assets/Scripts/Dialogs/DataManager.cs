using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public float newAlterId;
    public bool changePanel = false;
    public bool openPanel = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "AlterEgo")
        {
            IDGetter(collision);
            openPanel = true;

        }else if (collision.gameObject.tag == "AlterUsado")
        {
            openPanel = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        openPanel = false;
    }

    void IDGetter(Collider2D collision)
    {
        IDmanager manager = IDget(collision);

        IDCompare(collision, manager);
    }

    private IDmanager IDget(Collider2D collision)
    {
        collision.gameObject.name = "Alter_01";
        GameObject go = GameObject.Find("Alter_01");
        IDmanager manager = go.GetComponent<IDmanager>();
        newAlterId = manager.alterID;
        return manager;
    }

    private void IDCompare(Collider2D collision, IDmanager manager)
    {
        if (newAlterId == manager.alterID)
        {
            changePanel = true;
            Debug.Log(newAlterId);
            collision.gameObject.name = "AlterUsado";
            collision.gameObject.tag = "AlterUsado";
        }
    }
}
