using UnityEngine;

public class RotatingCoin : MonoBehaviour
{
    public float rotationSpeed = 60f;

    void Update()
    {
        // Rotar alrededor del eje Y local, nada de X ni Z
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime, Space.Self);


    }
}
