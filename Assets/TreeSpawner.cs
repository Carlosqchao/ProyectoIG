using UnityEngine;

public class RandomTreeSpawner : MonoBehaviour
{
    public GameObject treePrefab;
    public int treeCount = 100;

    public Terrain terrain;       // arrástralo desde la escena
    public float offsetY = 0f;    // por si quieres levantar un poco

    void Start()
    {
        if (terrain == null) terrain = Terrain.activeTerrain;
        if (terrain == null || treePrefab == null) return;

        TerrainData data = terrain.terrainData;
        Vector3 tPos = terrain.transform.position;
        Vector3 tSize = data.size;

        for (int i = 0; i < treeCount; i++)
        {
            // Posición XZ aleatoria dentro del terreno (en mundo)
            float x = Random.Range(tPos.x, tPos.x + tSize.x);
            float z = Random.Range(tPos.z, tPos.z + tSize.z);

            // Altura del terreno en esa XZ
            float yLocal = terrain.SampleHeight(new Vector3(x, 0f, z)); // altura relativa [web:18]
            float y = yLocal + tPos.y + offsetY; // corregir por la Y del Terrain [web:23]

            Vector3 pos = new Vector3(x, y, z);

            // Instanciar árbol (su pivote debe estar en la base)
            Instantiate(treePrefab, pos, Quaternion.identity, transform);
        }
    }
}
