using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGTilesHolder : MonoBehaviour
{
    Tiling[] tiles;
    int tilesAmount = 0;

    public void Start()
    {
        tiles = FindObjectsOfType<Tiling>();
        tilesAmount = tiles.Length;
    }

    public void AddTile(Tiling tileToAdd)
    {
        
        tiles[tilesAmount] = tileToAdd;
        tilesAmount++;
    }
}
