using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goalSoundController : MonoBehaviour
{
    [SerializeField] DataManager getData;
    [SerializeField] AudioSource goalSound;
    private bool goalReached;

    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Sounds");
        if (objs.Length > 1)
        {
            Destroy(this.gameObject);

            DontDestroyOnLoad(this.gameObject);
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        goalReached = getData.goal;
        if (goalReached == true)
        {
            goalSound.Play();
        }
    }
}
