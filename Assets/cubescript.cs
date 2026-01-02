using UnityEngine;

public class CubeScript : MonoBehaviour
{
    public Transform cubeTransform;
    public float velocity = 4f;
    public float jumpForce = 20f;
    private Vector3 position;
    private Rigidbody rb;
    private bool isGrounded = true;

    void Start()
    {
        cubeTransform = GetComponent<Transform>();
        position = cubeTransform.position;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Movimiento plano con Input.GetAxis
        position = cubeTransform.position;
        position.x += velocity * Time.deltaTime * Input.GetAxis("Horizontal");
        position.z += velocity * Time.deltaTime * Input.GetAxis("Vertical");
        cubeTransform.position = position;

        // Salto con física
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); // impulso hacia arriba
            isGrounded = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Muy simple: cualquier colisión se considera suelo
        isGrounded = true;
    }
}
