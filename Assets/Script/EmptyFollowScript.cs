using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyFollowScript : MonoBehaviour
{

    private void Update()
    {
        foreach (Transform child in transform)
        {
            if (child.gameObject.activeSelf)
            {
                this.transform.position = child.transform.position;
                break;
            }
        }
    }
}
