using UnityEngine;
using System.Collections;

public class playAnimationScript : MonoBehaviour
{

    [SerializeField] Animation yourAnimation;

    void Update()
    {
            yourAnimation.Play();        
    }
}
