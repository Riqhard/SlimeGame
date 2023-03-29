using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileSetBuilder : MonoBehaviour
{


    public TileSets tileset;
    

    public int width;
    public int height;

    [HideInInspector]
    public string seed;

    int[,] map;

    public void Start()
    {
        GenerateMap();
    }

    public void GenerateMap()
    {
        // Making Map
        map = new int[width, height];



        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                int numb = Random.Range(0, tileset.tiles.Length);
                
                map[x, y] = 1;

            }
        }

    }
}
