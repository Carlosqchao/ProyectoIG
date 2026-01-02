using System.Collections;
using UnityEngine;
using TMPro;

public class LevelTimer : MonoBehaviour
{
    public float timeLimit = 300f;              // 5 minutos
    public TextMeshProUGUI timerText;          // Asigna el texto del cronómetro
    public AudioClip loseSound;                // Asigna el sonido de derrota

    bool isRunning = true;
    bool hasLost = false;

    void Start()
    {
        UpdateUI();
    }

    void Update()
    {
        if (!isRunning) return;

        timeLimit -= Time.deltaTime;
        if (timeLimit <= 0f)
        {
            timeLimit = 0f;
            OnTimeOver();
        }

        UpdateUI();
    }

    void UpdateUI()
    {
        if (timerText == null) return;

        int seconds = Mathf.CeilToInt(timeLimit);
        int minutes = seconds / 60;
        int secs = seconds % 60;

        timerText.text = string.Format("{0:00}:{1:00}", minutes, secs); // [web:190]
    }

    void OnTimeOver()
    {
        if (hasLost) return;
        hasLost = true;
        isRunning = false;

        // Mensaje de derrota
        if (CoinCounter.Instance != null && CoinCounter.Instance.coinText != null)
            CoinCounter.Instance.coinText.text = "Has perdido, se acabó el tiempo";

        // Importante: NO pongas Time.timeScale = 0 aquí o la corrutina no avanzará

        if (loseSound != null)
            StartCoroutine(PlayLoseAndQuit());
        else
            QuitGame();
    }

    IEnumerator PlayLoseAndQuit()
    {
        // Crear un AudioSource temporal en la cámara (o en un objeto global)
        AudioSource src = Camera.main.gameObject.AddComponent<AudioSource>();
        src.clip = loseSound;
        src.playOnAwake = false;
        src.spatialBlend = 0f;           // 2D, se escucha siempre [web:198]
        src.ignoreListenerPause = true;  // por si pausas el listener [web:205]
        src.volume = 1f;

        src.Play();
        yield return new WaitForSeconds(src.clip.length); // esperar a que termine [web:214]

        QuitGame();
    }

    void QuitGame()
    {
        // Opcional: ahora sí puedes parar el tiempo si quieres congelar todo justo antes de salir
        Time.timeScale = 0f;        // [web:191]

#if !UNITY_EDITOR
        Application.Quit();         // cierra la app en build [web:215]
#else
        Debug.Log("QuitGame llamado (solo se cerrará en build)");
#endif
    }
}
