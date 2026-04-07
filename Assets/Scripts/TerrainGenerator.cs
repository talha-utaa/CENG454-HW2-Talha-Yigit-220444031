using UnityEngine;

public class ProceduralTerrainGenerator : MonoBehaviour
{
    [Header("Terrain Settings")]
    [SerializeField] private int heightmapResolution = 513;
    [SerializeField] private int terrainWidth = 1000;
    [SerializeField] private int terrainLength = 1000;
    [SerializeField] private int terrainHeight = 60;

    [Header("Noise Settings")]
    [SerializeField] private float noiseScale = 40f;
    [SerializeField] private float heightMultiplier = 0.15f;
    [SerializeField] private float offsetX = 100f;
    [SerializeField] private float offsetZ = 100f;

    [Header("Auto Create")]
    [SerializeField] private bool generateOnStart = true;

    private void Start()
    {
        if (generateOnStart)
        {
            GenerateTerrain();
        }
    }
    
    [ContextMenu("Generate Terrain")]
    public void GenerateTerrain()
    {
        TerrainData terrainData = new TerrainData();

        terrainData.heightmapResolution = heightmapResolution;
        terrainData.size = new Vector3(terrainWidth, terrainHeight, terrainLength);

        int resolution = terrainData.heightmapResolution;

        float[,] heights = new float[resolution, resolution];

        for (int z = 0; z < resolution; z++)
        {
            for (int x = 0; x < resolution; x++)
            {
                float sampleX = offsetX + (float)x / (resolution - 1) * noiseScale;
                float sampleZ = offsetZ + (float)z / (resolution - 1) * noiseScale;

                float noise = Mathf.PerlinNoise(sampleX, sampleZ);
                heights[z, x] = noise * heightMultiplier;
            }
        }

        terrainData.SetHeights(0, 0, heights);

        GameObject terrainObject = Terrain.CreateTerrainGameObject(terrainData);
        terrainObject.name = "ProceduralTerrain";
        terrainObject.transform.position = Vector3.zero;
    }
}