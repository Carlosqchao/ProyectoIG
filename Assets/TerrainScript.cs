using UnityEngine;

[ExecuteAlways]
public class SnapToTerrain : MonoBehaviour
{
    public float offsetY = 0f;

    void LateUpdate()
    {
        Terrain terrain = Terrain.activeTerrain;
        if (terrain == null) return;

        Vector3 pos = transform.position;

        // Altura local del terreno en XZ del árbol
        float terrainHeight = terrain.SampleHeight(pos);

        // Sumar la Y del Terrain porque tu Terrain no está en (0,0,0)
        pos.y = terrainHeight + terrain.transform.position.y + offsetY;

        transform.position = pos;
    }
}
