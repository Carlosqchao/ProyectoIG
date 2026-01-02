using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class SimpleFPSController : MonoBehaviour
{
    public float speed = 6f;
    public float mouseSensitivity = 2f;
    public float gravity = 9.81f;
    public float jumpForce = 5f;

    CharacterController controller;
    Camera cam;
    float verticalSpeed = 0f;
    float pitch = 0f; // rotación vertical

    void Start()
    {
        controller = GetComponent<CharacterController>();
        cam = GetComponentInChildren<Camera>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Rotación con ratón
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        transform.Rotate(0f, mouseX, 0f);

        pitch -= mouseY;
        pitch = Mathf.Clamp(pitch, -80f, 80f);
        cam.transform.localRotation = Quaternion.Euler(pitch, 0f, 0f);

        // Movimiento en plano XZ
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 move = transform.right * h + transform.forward * v;
        move *= speed;

        // Gravedad y salto
        if (controller.isGrounded)
        {
            verticalSpeed = -1f;
            if (Input.GetButtonDown("Jump"))
                verticalSpeed = jumpForce;
        }
        verticalSpeed -= gravity * Time.deltaTime;
        move.y = verticalSpeed;

        controller.Move(move * Time.deltaTime);
    }
}
