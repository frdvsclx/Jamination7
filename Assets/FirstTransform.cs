using MimicSpace;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FirstTransform : MonoBehaviour
{
    bool son=false;
    Mimic anan�;

    private void Start()
    {
        son = false;
        anan� = GameObject.FindAnyObjectByType<Mimic>();
    }

    private void Update()
    {
        if(son && Input.GetKeyDown(KeyCode.E))
        {
           
            anan�.enabled = false;
            Destroy(gameObject);
            son = true;
        }
    }
}
