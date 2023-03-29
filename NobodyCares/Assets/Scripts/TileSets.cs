using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "New Tileset", menuName = "TileSet")]
public class TileSets : ScriptableObject
{

    public string tileSetName = "New tileSet";

    [System.Serializable]
    public class Tiles
    {
        public Sprite tiles;
        // High Rarity = less change of being this.
        // 1-10
        [Range(1,10)]
        public int rarity;
    }

    public Tiles[] tiles;


}
