using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrubsGenerator : MonoBehaviour
{

    public int amountOfShrubs;

    public Sprite[] sprites;
    public GameObject shrubsPoint;
    public SpriteRenderer sprite;
    float tileWidth;
    float tileHeight;
    

    // Start is called before the first frame update
    void Start()
    {
        tileWidth = sprite.sprite.bounds.size.x;
        tileHeight = sprite.sprite.bounds.size.y;


        for (int i = 0; i < amountOfShrubs; i++)
        {
            Vector3 placement = GetRandomPosition();



            GameObject clone = Instantiate(shrubsPoint, transform.position + placement, transform.rotation, transform);
            int numb = Random.Range(0, sprites.Length);
            clone.GetComponent<SpriteRenderer>().sprite = sprites[numb];

            
        }
    }

    public Vector3 GetRandomPosition()
    {
        float xAxis = Random.Range(0f, tileWidth / 2);
        float yAxis = Random.Range(0f, tileHeight / 2);
        int upOrDown = Random.Range(0, 2);
        int leftOrRight = Random.Range(0, 2);
        Vector3 placement;

        if (upOrDown == 1)
        {
            if (leftOrRight == 1)
            {
                placement = new Vector3(xAxis, yAxis);
            }
            else
            {
                placement = new Vector3(xAxis, -yAxis);
            }
        }
        else
        {
            if (leftOrRight == 1)
            {
                placement = new Vector3(-xAxis, yAxis);
            }
            else
            {
                placement = new Vector3(-xAxis, -yAxis);
                
            }
        }
        return placement;
    }
}
