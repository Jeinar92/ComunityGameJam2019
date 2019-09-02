using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smoke_Animation : MonoBehaviour
{
    [SerializeField] Animation yourAnimation;

    void Update()
    {
        yourAnimation.Play();
    }
}
