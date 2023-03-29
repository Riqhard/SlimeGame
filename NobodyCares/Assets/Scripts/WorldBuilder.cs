using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldBuilder : MonoBehaviour
{

    public GameObject treeTile;
    public GameObject emptyTile;

    public int width;
    public int height;

    public string seed;
    public bool useRandomSeed;


    public class Node
    {
        int[,] position;
        int[,] filledTiles;
    }

    [Range(0, 100)]
    public float randomFillPercent;

    int[,] map;

    public void Start()
    {
        GenerateMap();
    }

    public void GenerateMap()
    {
        

        map = new int[width, height];
        RandomFillMap();
        for (int i = 0; i < 5; i++)
        {
            SmoothMap();
        }

        // Place Ground tile on all Map cordinates with value of 1
        PlacingTiles();
    }

    public void RandomFillMap()
    {
        if (useRandomSeed)
        {
            seed = Time.time.ToString();
        }

        System.Random pseudoRandom = new System.Random(seed.GetHashCode());

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {

                    map[x, y] = (pseudoRandom.Next(0, 100) < randomFillPercent) ? 1 : 0;

            }
        }
    }
    public void SmoothMap()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                int neighbourWallTiles = GetSurroundingWallCount(x, y);

                if (neighbourWallTiles > 4)
                {
                    map[x, y] = 1;
                }
                else if (neighbourWallTiles < 4)
                {
                    map[x, y] = 0;
                }
            }
        }
    }
    int GetSurroundingWallCount(int gridX, int gridY)
    {
        int wallCount = 0;

        for (int neighbourX = gridX - 1; neighbourX <= gridX + 1; neighbourX++)
        {
            for (int neighbourY = gridY - 1; neighbourY <= gridY + 1; neighbourY++)
            {
                if (neighbourX >= 0 && neighbourX < width && neighbourY >= 0 && neighbourY < height)
                {
                    if (neighbourX != gridX || neighbourY != gridY)
                    {
                        wallCount += map[neighbourX, neighbourY];
                    }
                }
                else
                {
                    wallCount++;
                }

            }
        }
        return wallCount;
    }

    public void PlacingTiles()
    {
        if (map != null)
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Vector2 pos = new Vector2(-width / 2 + x + .5f, -height / 2 + y + .5f);
                }
            }
        }
    }


    struct Coord
    {
        public int tileX;
        public int tileY;

        public Coord(int x, int y)
        {
            tileX = x;
            tileY = y;
        }
    }

    private void OnDrawGizmos()
    {
        if (map != null)
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Gizmos.color = (map[x, y] == 1) ? Color.black : Color.white;
                    Vector2 pos = new Vector2(-width / 2 + x + .5f, -height / 2 + y + .5f);
                    Gizmos.DrawCube(pos, Vector2.one);
                }
            }
        }
    }
}
