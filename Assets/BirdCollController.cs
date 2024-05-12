using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdCollController : MonoBehaviour
{
    private CharacterController characterController;
    bool Force = false;



    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        characterController.enabled = false;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.W) && Force)
        {
            characterController.enabled=false;
            Force = false;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Coll"))
        {
            characterController.enabled = true;
        }
    }


    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.CompareTag("Coll"))
        {
            characterController.enabled = false;
        }
    }
}
