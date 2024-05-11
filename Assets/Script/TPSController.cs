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
    private float lookXLimit = 45f;


    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;


    CharacterController characterController;
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

    void MouseMove()
    {

        characterController.Move(moveDirection * Time.deltaTime);


        rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
        rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
        Cam.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);

    }
}
