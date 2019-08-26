using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{   [Range (0f, 0.2f)]
    [SerializeField] float parallaxSpeed = 0.02f;
    [SerializeField] float characterSpeed = 10f;
    public RawImage background;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float finalCharacterSpeed = characterSpeed * Time.deltaTime;
        float finalSpeed =characterSpeed * parallaxSpeed * Time.deltaTime;
        background.uvRect = new Rect(background.uvRect.x + finalSpeed, 0f, 1f, 1f);
    }
}
