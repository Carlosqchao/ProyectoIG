using UnityEngine;
using TMPro;

public class CoinCounter : MonoBehaviour
{
    public static CoinCounter Instance { get; private set; }

    public int currentCoins = 0;
    public int totalCoins = 30;

    public TextMeshProUGUI coinText;   // ÚNICO texto en la UI
    public AudioClip winSound;         // Sonido al completar

    bool completed = false;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    void Start()
    {
        UpdateUI();
    }

    public void AddCoin(int amount)
    {
        if (completed) return;

        currentCoins += amount;
        if (currentCoins > totalCoins) currentCoins = totalCoins;

        UpdateUI();

        if (currentCoins >= totalCoins)
            OnCompleted();
    }

    void UpdateUI()
    {
        if (coinText != null && !completed)
            coinText.text = currentCoins + " / " + totalCoins;
    }

    void OnCompleted()
{
    completed = true;

    // Detener música de fondo
    if (MusicManager.Instance != null)
        MusicManager.Instance.OnGameWin();

    // Cambiar el texto al mensaje final
    if (coinText != null)
        coinText.text = "¡Enhorabuena, juego superado!";

    // Sonido de victoria una sola vez
    if (winSound != null && Camera.main != null)
        AudioSource.PlayClipAtPoint(winSound, Camera.main.transform.position, 1f);
}

}
