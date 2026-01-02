using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;

    AudioSource musicSource;

    void Awake()
    {
        // Singleton para tener solo un MusicManager
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);          // opcional si usas varias escenas [web:311]

        musicSource = GetComponent<AudioSource>();

        // Asegurar configuración de loop
        musicSource.loop = true;                // que se repita [web:302]
        if (!musicSource.isPlaying && musicSource.clip != null)
            musicSource.Play();
    }

    // Llamar cuando el jugador gane
    public void OnGameWin()
    {
        StopMusic();
    }

    // Llamar cuando el jugador pierda
    public void OnGameLose()
    {
        StopMusic();
    }

    void StopMusic()
    {
        if (musicSource != null)
            musicSource.Stop();                 // detiene la música [web:320][web:321]
    }
}
