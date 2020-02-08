using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(Tilemap))]
public class TilemapGenerator : MonoBehaviour
{
    [Range(0, 1)]
    public float treeProbability;
    [Range(0, 1)]
    public float horseProbability;
    [Range(0, 1)]
    public float ironOreProbability;
    public int grassDepth;
    public int maximumSurfaceDepth;
    public int underGroundDepth;
    public TileBase dirtTile;
    public TileBase ironOre;
    public TileBase grassTile;
    private Tilemap tilemap;
    public TileBase treeTile;
    public TileBase leafTile;
    public TileBase horseTile;
    bool located = false;
    public GameObject player;
    [Header("Noise settings")]
    public int mapWidth;
    public int seed;
    public float scale;
    public int octaves;
    public float persistance;
    public float lacunarity;
    public Vector2 offset;

    // Start is called before the first frame update
    void Start()
    {
        tilemap = GetComponent<Tilemap>();

        float[,] map = Noise.GenerateNoiseMap(mapWidth, 1, seed, scale, octaves, persistance, lacunarity, offset);

        for (int x = 0; x < mapWidth; x++)
        {
            int y = 0;
            while (y < underGroundDepth)
            {
                tilemap.SetTile(new Vector3Int(x, y, 0), Random.value <= ironOreProbability ? ironOre : dirtTile);
                y++;
            }
            float currentSurfaceDepth = map[x, 0] * maximumSurfaceDepth;
            while (y < currentSurfaceDepth + underGroundDepth)
            {
                tilemap.SetTile(new Vector3Int(x, y, 0), y > currentSurfaceDepth + underGroundDepth - grassDepth ? grassTile : dirtTile);
                if (y == Mathf.Floor(currentSurfaceDepth + underGroundDepth))
                {
                    if (Random.value <= treeProbability)
                    {
                        tilemap.SetTile(new Vector3Int(x, y + 1, 0), treeTile);
                        tilemap.SetTile(new Vector3Int(x, y + 2, 0), treeTile);
                        tilemap.SetTile(new Vector3Int(x, y + 3, 0), treeTile);
                        tilemap.SetTile(new Vector3Int(x, y + 4, 0), treeTile);
                        tilemap.SetTile(new Vector3Int(x, y + 5, 0), leafTile);

                        tilemap.SetTile(new Vector3Int(x + 1, y + 5, 0), leafTile);
                        tilemap.SetTile(new Vector3Int(x - 1, y + 5, 0), leafTile);
                        tilemap.SetTile(new Vector3Int(x - 1, y + 6, 0), leafTile);
                        tilemap.SetTile(new Vector3Int(x + 1, y + 6, 0), leafTile);
                        tilemap.SetTile(new Vector3Int(x + 1, y + 6, 0), leafTile);
                        tilemap.SetTile(new Vector3Int(x - 1, y + 6, 0), leafTile);
                        tilemap.SetTile(new Vector3Int(x, y + 6, 0), leafTile);
                    }
                    else if (Random.value <= horseProbability)
                    {
                        tilemap.SetTile(new Vector3Int(x, y + 1, 0), horseTile);
                    }
                }
                y++;
            }
        }
        int spawnXPosition = Random.Range(0, mapWidth);
        for (int y = underGroundDepth + maximumSurfaceDepth; y > 0; y--)
        {
            if (tilemap.GetTile(new Vector3Int(spawnXPosition, y, 0)))
            {
                Instantiate(player, tilemap.CellToWorld(new Vector3Int(spawnXPosition, y, 0)) + new Vector3(0.5f, 1.5f), Quaternion.identity);
                break;
            }
        }
    }
}
