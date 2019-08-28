using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public float newAlterId;
    public float newLiarId;
    public bool changePanel = false;
    public bool openLiarButton = false;
    public bool openPanel = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "AlterEgo")
        {
            IDGetter(collision);
            openPanel = true;

        }else if (collision.gameObject.tag == "SpokenAlter")
        {
            openPanel = false;
        }
        else if (collision.gameObject.tag == "Liar")
        {
            LiarIDGetter(collision);
            openPanel = true;
            openLiarButton = true;
        }
        else if (collision.gameObject.tag == "SpokenLiar")
        {
            openPanel = false;
            openLiarButton = false;
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

    void LiarIDGetter (Collider2D collision)
    {
        LiarIDManager liarManager = IDLiarGet(collision);

        IDLiarCompare(collision, liarManager);
    }

    private IDmanager IDget(Collider2D collision)
    {      
        collision.gameObject.name = "Alter_01";
        GameObject go = GameObject.Find("Alter_01");
        IDmanager manager = go.GetComponent<IDmanager>();
        newAlterId = manager.alterID;
        return manager;
    }

    private LiarIDManager IDLiarGet(Collider2D collision)
    {
        collision.gameObject.name = "Liar";
        GameObject liarGO = GameObject.Find("Liar");
        LiarIDManager liarManager = liarGO.GetComponent<LiarIDManager>();
        newLiarId = liarManager.liarID;
        return liarManager;
    }

    private void IDLiarCompare(Collider2D collision, LiarIDManager liarManager)
    {
        if (newLiarId == liarManager.liarID)
        {
            changePanel = true;
            Debug.Log(newLiarId);
            collision.gameObject.name = "SpokenLiar";
            collision.gameObject.tag = "SpokenLiar";
        }
    }

    private void IDCompare(Collider2D collision, IDmanager manager)
    {
        if (newAlterId == manager.alterID)
        {
            changePanel = true;
            Debug.Log(newAlterId);
            collision.gameObject.name = "SpokenAlter";
            collision.gameObject.tag = "SpokenAlter";
        }
    }
}
