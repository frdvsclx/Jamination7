using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class BirdController : MonoBehaviour
{
    public float FlySpeed = 5f;
    public float YawAmount = 120;

    private float Yaw;
    [SerializeField]
    private Camera Cam;

    private Transform Camera;



    private float lookSpeed = 2f;
    private float lookXLimit = 180f;


    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;


    CharacterController characterController;
    public Vector3 cameraOffset = new Vector3(0, 3, -10);
    public float cameraFollowSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Camera = GameObject.FindGameObjectWithTag("MainCamera").transform;
        Cam = GameObject.FindAnyObjectByType<Camera>();

    }

    // Update is called once per frame
    void Update()
    {
        // move forward
        transform.position += transform.forward * FlySpeed * Time.deltaTime;

        // inputs
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // apply rotation
        Yaw += horizontalInput * YawAmount * Time.deltaTime;
        float pitch = Mathf.Lerp(0, 70, Mathf.Abs(verticalInput)) * Mathf.Sign(verticalInput);
        float roll = Mathf.Lerp(0, 30, Mathf.Abs(horizontalInput)) * -Mathf.Sign(horizontalInput);

        transform.localRotation = Quaternion.Euler(Vector3.up * Yaw + Vector3.right * pitch + Vector3.forward * roll);

        MouseMove();
        CamMove();
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


