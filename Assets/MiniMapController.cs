using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapController : MonoBehaviour
{
    private Transform MainCam;

    private void Start()
    {
        MainCam = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }
    private void LateUpdate()
    {
        Vector3 NewPos = MainCam.position;
        NewPos.y = transform.position.y;
        transform.position = NewPos;
        transform.rotation = Quaternion.Euler(90f, MainCam.eulerAngles.y, 0f);
    }
}
