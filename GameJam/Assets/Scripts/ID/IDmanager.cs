using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IDmanager : MonoBehaviour
{
    public float alterID;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Spawn")
        {
            alterID = collision.gameObject.GetComponent<NpcSpawn>().IDgiver;
            collision.gameObject.GetComponent<Collider2D>().enabled = false;
            Debug.Log("ID GIVEN");
        }
    }

   
}
