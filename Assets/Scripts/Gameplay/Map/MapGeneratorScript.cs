using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapGeneratorScript : MonoBehaviour
{
    public int mapWidth = 10;
    public int mapHeight = 10;

    public Tilemap tilemap;

    void Start()
    {
        GenerateMap();
    }

    void GenerateMap()
    {
        for (int x = 0; x < mapWidth; x++)
        {
            for (int y = 0; y < mapHeight; y++)
            {
                Vector3Int tilePos = new Vector3Int(x, y, 0);
                //tilemap.SetTile(tilePos, GetRandomTile());
            }
        }
    }

    //TileBase GetRandomTile()
    //{
    //    int rand = Random.Range(0, tilePalette.tiles.Count);
    //    return tilePalette.tiles[rand];
    //}
}
