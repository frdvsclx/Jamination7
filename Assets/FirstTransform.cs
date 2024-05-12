using MimicSpace;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FirstTransform : MonoBehaviour
{
    bool son=false;
    Mimic ananý;

    private void Start()
    {
        son = false;
        ananý = GameObject.FindAnyObjectByType<Mimic>();
    }

    private void Update()
    {
        if(son && Input.GetKeyDown(KeyCode.E))
        {
           
            ananý.enabled = false;
            Destroy(gameObject);
            son = true;
        }
    }
}
