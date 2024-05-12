using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class BirdController2 : MonoBehaviour
{
    [SerializeField] private float speed, levitationSpeed;
    private Vector3 moveDirection1;

    [SerializeField]
    private Camera Cam;

    private Transform Camera;



    private float lookSpeed = 2f;
    private float lookXLimit = 180f;


    Vector3 moveDirection2 = Vector3.zero;
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
        Move();
        Fly();
        MouseMove();
        CamMove();
    }

    private void Fly()
    {
        moveDirection1 = Vector3.up * levitationSpeed * Time.deltaTime;

        if (Input.GetKey(KeyCode.Space))
        {
            characterController.Move(moveDirection1);
        }
        else if (Input.GetKey(KeyCode.LeftShift))
        {
            characterController.Move(-moveDirection1);
        }
    }

    private void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float verticalInput = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        Vector3 move = transform.forward * verticalInput + transform.right * horizontalInput;

        characterController.Move(move);
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

        characterController.Move(moveDirection2 * Time.deltaTime);


        rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
        rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
        Cam.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);

    }


}
