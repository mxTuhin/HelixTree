using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalSetCollider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameManager.instance.menuCanvas.SetActive(true);
        GameManager.instance.endingText.text = "Level Complete";
        StaticVars.inGame = false;
    }
}
