using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MimicCamera : MonoBehaviour
{
    [SerializeField]
    private Camera Cam;

    private Transform Camera;



    private float lookSpeed = 2f;
    private float lookXLimit = 180f;


    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;


    CharacterController characterController;
    public Vector3 cameraOffset = new Vector3(0, 2, -4);
    public float cameraFollowSpeed = 5f;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Camera = GameObject.FindGameObjectWithTag("MainCamera").transform;
        Cam = GameObject.FindAnyObjectByType<Camera>();

    }
    private void Update()
    {
        CamMove();
        MouseMove();
    }
    void CamMove()
    {
        Vector3 targetPosition = transform.position + transform.TransformDirection(cameraOffset);
        Camera.position = Vector3.Lerp(Camera.position, targetPosition, cameraFollowSpeed * Time.deltaTime);
        Camera.LookAt(transform);
        Quaternion targetRotation = Quaternion.LookRotation(transform.position - Camera.position);
        Camera.rotation = Quaternion.Slerp(Camera.rotation, targetRotation, cameraFollowSpeed * Time.deltaTime);
    }
    void MouseMove()
    {

        characterController.Move(moveDirection * Time.deltaTime);


        rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
        rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
        Cam.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);

    }
}
