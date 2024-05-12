using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class TPSController : MonoBehaviour
{
    [SerializeField]
    private Camera Cam;
    private float walkSpeed = 6f;

    private Transform Camera;

    private float RunSpeed = 10f;


    private float lookSpeed = 2f;
    private float lookXLimit = 60f;


    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;


    CharacterController characterController;
    public Vector3 cameraOffset = new Vector3(0, 2, -4);
    public float cameraFollowSpeed = 5f;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Camera = GameObject.FindGameObjectWithTag("MainCamera").transform;
        Cam = GameObject.FindAnyObjectByType<Camera>();


    }

    void Update()
    {
        Move();
        MouseMove();
        CamMove();

    }

    void Move()
    {

        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        bool isRunning = Input.GetKey(KeyCode.LeftShift);

        float curSpeedX = (isRunning ? RunSpeed : walkSpeed) * Input.GetAxis("Vertical");
        float curSpeedY = (isRunning ? RunSpeed : walkSpeed) * Input.GetAxis("Horizontal");
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        moveDirection.y -= walkSpeed * Time.deltaTime * 100 * 100 * 10;




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
        rotationX = Mathf.Clamp(rotationX,-lookXLimit,lookXLimit);

        Cam.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);

        transform.rotation *= Quaternion.Euler(0,Input.GetAxis("Mouse X")*lookSpeed, 0);
        //rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
        //Cam.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        //transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);

    }


}
