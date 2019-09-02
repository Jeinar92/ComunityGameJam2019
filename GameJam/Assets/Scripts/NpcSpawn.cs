using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcSpawn : MonoBehaviour
{

    public float IDgiver;                                             // Var for sendding id to alterprefab at spawn
    public GameObject spawnPrefab;
    //[SerializeField] Animation anim;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            Instantiate(spawnPrefab, this.transform.position, Quaternion.identity);
           // this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
            //anim.wrapMode = WrapMode.Once;
           
        }
    }
    
    
}
