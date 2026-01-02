using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;
    public int coinCount = 30;
    public Terrain terrain;
    public float offsetY = 0.2f;

    void Start()
    {
        if (terrain == null) terrain = Terrain.activeTerrain;
        if (terrain == null || coinPrefab == null) return;

        TerrainData data = terrain.terrainData;
        Vector3 tPos = terrain.transform.position;
        Vector3 tSize = data.size;

        for (int i = 0; i < coinCount; i++)
        {
            float x = Random.Range(tPos.x, tPos.x + tSize.x);
            float z = Random.Range(tPos.z, tPos.z + tSize.z);

            float yLocal = terrain.SampleHeight(new Vector3(x, 0f, z)); // [web:18]
            float y = yLocal + tPos.y + offsetY;                        // [web:19]

            Quaternion rot = coinPrefab.transform.rotation;
            Instantiate(coinPrefab, new Vector3(x, y, z), rot, transform);

        }
    }
}
