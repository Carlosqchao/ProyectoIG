using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    public AudioClip pickupSound;
    public int value = 1;

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        // Sumar monedas
        CoinCounter.Instance.AddCoin(value);

        // Sonido en el mundo
        if (pickupSound != null)
            AudioSource.PlayClipAtPoint(pickupSound, transform.position, 1f); // [web:130]

        // Destruir moneda
        Destroy(gameObject);
    }
}
