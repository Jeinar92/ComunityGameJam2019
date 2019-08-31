using UnityEngine;
using System.Collections;

public class playAnimationScript : MonoBehaviour
{

    [SerializeField] Animation yourAnimation;

    
    // This is an example only

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            yourAnimation.Play();
        }
    }
}
