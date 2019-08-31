using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public float newAlterId;                                    //Alter Id got from collision
    public float newLiarId;                                     //Liar id got from collision
    public float newNormalId;                                   //Normal id got from collision
    public bool changePanel = false;                            // bool to load new text on panel on collision
    public bool openPanel = false;                              //Bool to open panel on collision
    public bool openLiarButton = false;                         //Bool to open liar accept button on collision
    public bool openNormalButton = false;                       //Bool to open normal accept button on collision
    public bool openAlterButton = false;                        //Bool to open alter accept button on collision
    public bool openDeclineButton = false;
    public bool goal = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "AlterEgo")
        {
            AlterIDGetter(collision);
            openPanel = true;
            openAlterButton = true;
            openDeclineButton = true;
        }
        else if (collision.gameObject.tag == "SpokenAlter")
        {
            openPanel = false;
            openAlterButton = false;
            openDeclineButton = false;
        }
        else if (collision.gameObject.tag == "Liar")
        {
            LiarIDGetter(collision);
            openPanel = true;
            openLiarButton = true;
            openDeclineButton = true;
        }
        else if (collision.gameObject.tag == "SpokenLiar")
        {
            openPanel = false;
            openLiarButton = false;
            openDeclineButton = false;

        }
        else if (collision.gameObject.tag == "NormalObject")
        {
            NormalIDGetter(collision);
            openPanel = true;
            openNormalButton = true;
        }        
        else if (collision.gameObject.tag == "Goal")
        {
            NormalIDGetter(collision);
            openPanel = true;
            openNormalButton = true;
            goal = true;

        }else if (collision.gameObject.tag == "SpokenNormal")
        {
            openPanel = false;
            openNormalButton = false;
            goal = false;
        }
        
    }

    void AlterIDGetter(Collider2D collision)
    {
        IDmanager alterManager = AlterIDGet(collision);

        AlterIDCompare(collision, alterManager);
    }

    void LiarIDGetter (Collider2D collision)
    {
        LiarIDManager liarManager = IDLiarGet(collision);

        LiarIDCompare(collision, liarManager);
    }

    void NormalIDGetter(Collider2D collision)
    {
        NormalIDManager normalManager = NormalIDGet(collision);

        NormalIDCompare(collision, normalManager);
    }

    private IDmanager AlterIDGet(Collider2D collision)
    {      
        collision.gameObject.name = "Alter_01";
        GameObject alterGo = GameObject.Find("Alter_01");
        IDmanager alterManager = alterGo.GetComponent<IDmanager>();
        newAlterId = alterManager.alterID;
        return alterManager;
    }

    private NormalIDManager NormalIDGet(Collider2D collision)
    {
        collision.gameObject.name = "normalObject";
        GameObject normalGO = GameObject.Find("normalObject");
        NormalIDManager normalManager = normalGO.GetComponent<NormalIDManager>();
        newNormalId = normalManager.ID;
        return normalManager;
    }
    private LiarIDManager IDLiarGet(Collider2D collision)
    {
        collision.gameObject.name = "Liar";
        GameObject liarGO = GameObject.Find("Liar");
        LiarIDManager liarManager = liarGO.GetComponent<LiarIDManager>();
        newLiarId = liarManager.liarID;
        return liarManager;
    }

    private void NormalIDCompare(Collider2D collision, NormalIDManager normalManager)
    {
        if (newNormalId == normalManager.ID)
        {
            changePanel = true;
            Debug.Log(newNormalId);
            collision.gameObject.name = "SpokenNormal";
            collision.gameObject.tag = "SpokenNormal";
        }
    }

    private void LiarIDCompare(Collider2D collision, LiarIDManager liarManager)
    {
        if (newLiarId == liarManager.liarID)
        {
            changePanel = true;
            Debug.Log(newLiarId);
            collision.gameObject.name = "SpokenLiar";
            collision.gameObject.tag = "SpokenLiar";
        }
    }
    private void AlterIDCompare(Collider2D collision, IDmanager manager)
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
