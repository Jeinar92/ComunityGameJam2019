using UnityEngine;
using System.Collections;

public class playAnimationScript : MonoBehaviour
{

    [SerializeField] Animation anim;

    void Update()
    {
            anim.Play();        
    }
}
