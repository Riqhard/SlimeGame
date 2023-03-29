using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Work in Progress.
public class Tiling : MonoBehaviour
{
    public GameObject BGTile;

    public int posX = 0;
    public int posY = 0;



    public int offsetX = 2;
    public int offsetY = 2;

    bool leftBuddy;
    bool rightBuddy;
    bool topBuddy;
    bool bottomBuddy;

    float tileWidth;
    float tileHeight;

    public Camera cam;
    BGTilesHolder tilesHolder;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        tileWidth = sprite.sprite.bounds.size.x;
        tileHeight = sprite.sprite.bounds.size.y;
        tilesHolder = FindObjectOfType<BGTilesHolder>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!leftBuddy || !rightBuddy || !topBuddy || !bottomBuddy)
        {
            float camHorizontalExtension = cam.orthographicSize * Screen.width / Screen.height;
            float camVErticalExtension = cam.orthographicSize * Screen.height / Screen.width;

            float edgeVisibilityRight = (transform.position.x + tileWidth / 2) - camHorizontalExtension;
            float edgeVisibilityLeft = (transform.position.x - tileWidth / 2) + camHorizontalExtension;

            if (cam.transform.position.x >= edgeVisibilityRight - offsetX && !rightBuddy)
            {
                rightBuddy = true;
            }
            else if (cam.transform.position.x <= edgeVisibilityRight + offsetX && !leftBuddy)
            {
                leftBuddy = true;
            }
        }
    }

    public void MakeNewBuddy(int directionX, int directionY)
    {
        Vector3 newpos = new Vector3(transform.position.x + tileWidth * directionX, transform.position.y + tileHeight * directionY, transform.position.z);
        GameObject newTile = Instantiate(BGTile, newpos, transform.rotation);
        tilesHolder.AddTile(newTile.GetComponent<Tiling>());
    }


    public void UpdatePositions(int newPosX, int newPosY)
    {
        posX = newPosX;
        posY = newPosY;
    }
}
