using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiarIDManager : MonoBehaviour
{
    public float liarID;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Spawn")
        {
            liarID = collision.gameObject.GetComponent<NpcSpawn>().IDgiver;
            collision.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            collision.gameObject.GetComponent<Collider2D>().enabled = false;
            Debug.Log("ID GIVEN");
        }
    }
}

