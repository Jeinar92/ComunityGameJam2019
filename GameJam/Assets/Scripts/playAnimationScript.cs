using UnityEngine;
using System.Collections;

public class playAnimationScript : MonoBehaviour
{

    [SerializeField] Animation yourAnimation;

    
    // This is an example only

    void Update()
    {
        
            yourAnimation.Play();
        
    }
}
