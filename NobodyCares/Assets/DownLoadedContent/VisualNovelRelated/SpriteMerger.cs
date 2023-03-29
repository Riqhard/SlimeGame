using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteMerger : MonoBehaviour
{
    public Sprite[] spritesToMerge = null;
    public SpriteRenderer finalSpriteRenderer = null;

    private void Start()
    {
        Merge();
    }

    public void Merge()
    {
        Resources.UnloadUnusedAssets();

        // Initializing the Picture.
        var newTex = new Texture2D(505,600);

        // Looping through all the pixels on the img.
        for (int x = 0; x < newTex.width; x++)
        {
            for (int y = 0; y < newTex.height; y++)
            {
                // Setting all the pixels Transparent
                newTex.SetPixel(x, y, new Color(1, 1, 1, 0));
            }
        }

        for (int i = 0; i < spritesToMerge.Length; i++)
        {
            for (int x = 0; x < spritesToMerge[i].texture.width; x++)
            {
                for (int y = 0; y < spritesToMerge[i].texture.height; y++)
                {
                    // If the pixel we are looking at on the mergin image is Transparent. Don't Draw anything on it
                    // If not. Then Draw what is on the mergin image.
                    var color = spritesToMerge[i].texture.GetPixel(x, y).a == 0 ?
                        newTex.GetPixel(x, y) :
                        spritesToMerge[i].texture.GetPixel(x, y);


                    newTex.SetPixel(x, y, color);

                }
            }
        }

        newTex.Apply();
        var finalSprite = Sprite.Create(newTex, new Rect(0, 0, newTex.width, newTex.height), new Vector2(0.5f, 0.5f));
        finalSprite.name = "New Sprite";
        finalSpriteRenderer.sprite = finalSprite;

    }
}
