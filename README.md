# Proyecto IG-S14
Autores: Juan Boissier García y Carlos Ruano Ramos
Resumen
- Proyecto Unity (3D) con objetivo de recoger monedas antes de que termine el tiempo.
- Solución Visual Studio: `IG-S14.slnx`.

Estructura principal
- Assets/: código C#, prefabs, audios, terrenos y escenas.
- Packages/: paquetes de Unity.
- ProjectSettings/: ajustes del proyecto (versión de Unity, configuración de entrada, etc.).
- IG-S14.slnx: solución para editar scripts en Visual Studio.

Versión de Unity
- Comprueba el archivo `ProjectSettings/ProjectVersion.txt` para ver la versión exacta de Unity usada.

Scripts principales (resumen)
- Assets/PlayerControl.cs: controlador FPS simple (movimiento, mirada con ratón y salto).
- Assets/CoinSpawner.cs: genera monedas aleatoriamente sobre el terreno (`coinPrefab`, `coinCount`, `terrain`).
- Assets/CoinPickup.cs: comportamiento de recogida — suma monedas, reproduce sonido y destruye la moneda al colisionar con el jugador.
- Assets/RotatingCoin.cs: rota la moneda continuamente.
- Assets/coinCounter.cs (CoinCounter): singleton que lleva el recuento de monedas, actualiza UI y maneja la condición de victoria (reproduce sonido, detiene música, muestra mensaje).
- Assets/LevelTimer.cs: temporizador de nivel (cuenta regresiva), muestra tiempo en `TextMeshProUGUI`, reproduce sonido de derrota y finaliza partida si se agota el tiempo.
- Assets/MusicManager.cs: singleton para música de fondo (AudioSource), reproducción en bucle y parada en victoria/derrota.
- Otros scripts detectados: `cubescript.cs`, `TreeSpawner.cs`, `TerrainScript.cs` y ejemplos de TextMeshPro (carpeta `TextMesh Pro/Examples & Extras`).

Assets y configuración relevantes
- Terreno: archivos `TerrainData_*` y `New Terrain.asset` presentes en `Assets/`.
- Prefabs: monedas/prefabs (buscar en `Assets/Prefabs` si existe).
- UI: Usa TextMeshPro para contador y temporizador (asegúrate de asignar referencias en el Inspector).
- Sonidos: varios archivos .mp3 referenciados en `Assets/` (efectos de moneda, música, victoria/derrota).

Cómo abrir y ejecutar
1. Abrir Unity Hub y seleccionar la carpeta del proyecto (la raíz donde está `ProjectSettings/`).
2. Abrir la escena principal desde la ventana `File > Open Scene` (buscar en `Assets/Scenes` si existe).
3. En el Inspector, asignar referencias:
   - `CoinSpawner`: asignar `coinPrefab` y `terrain` (si no se auto-detecta).
   - `CoinCounter`: asignar `coinText` (TextMeshProUGUI) y `winSound` opcional.
   - `LevelTimer`: asignar `timerText` (TextMeshProUGUI) y `loseSound` opcional.
   - `MusicManager`: asegurarse de que tenga `AudioSource` con clip y `DontDestroyOnLoad` si se desea persistencia.
4. Pulsar Play en el Editor para probar.

Notas y recomendaciones
- Revisa y ajusta `totalCoins` en `CoinCounter` y `coinCount` en `CoinSpawner` para equilibrar el nivel.
- Si la escena no carga o faltan referencias, busca todos los `.unity` en `Assets/` y abre la que sea la principal.
- TextMeshPro viene con ejemplos; puedes eliminarlos si deseas limpiar el proyecto.

Archivos clave a revisar
- [IG-S14.slnx](IG-S14.slnx)
- [ProjectSettings](ProjectSettings)
- [Assets/PlayerControl.cs](Assets/PlayerControl.cs)
- [Assets/CoinSpawner.cs](Assets/CoinSpawner.cs)
- [Assets/CoinPickup.cs](Assets/CoinPickup.cs)
- [Assets/coinCounter.cs](Assets/coinCounter.cs)
- [Assets/LevelTimer.cs](Assets/LevelTimer.cs)
- [Assets/MusicManager.cs](Assets/MusicManager.cs)

Siguientes pasos sugeridos
- Probar la escena en Editor y ajustar referencias UI/Audio.
- Añadir instrucciones específicas de build (plataforma target) si quieres un ejecutable.

Si quieres, puedo:
- Añadir instrucciones de build para Windows/Android/iOS.
- Extraer una lista completa de escenas y assets usados por la escena principal.
- Generar un CHANGELOG o empaquetar prefabs importantes.

---
Generado automáticamente: resumen básico del proyecto. 
