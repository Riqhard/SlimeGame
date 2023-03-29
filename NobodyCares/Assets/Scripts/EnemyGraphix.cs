using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGraphix : MonoBehaviour
{

    PlayerMovement player;
    private bool m_FacingRight = true;
    private bool m_TopLayer = true;

    float fade = 1f;
    bool isDissolving = false;

    public SpriteRenderer[] mats;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (isDissolving)
        {
            fade -= Time.deltaTime;
            if (fade <= 0)
            {
                fade = 0;
                isDissolving = false;
            }

            foreach (SpriteRenderer item in mats)
            {
                item.material.SetFloat("_Fade", fade);

            }

            return;
        }
        
        Vector2 direction = (player.transform.position - transform.position).normalized;

        if (direction.x > 0)
        {
            //Face left
            if (m_FacingRight)
            {
                Flip();
            }
        }
        else
        {
            //Face right
            if (!m_FacingRight)
            {
                Flip();
            }
        }


        if (direction.y > 0)
        {
            //Face UP
            if (!m_TopLayer)
            {
                ChangeLayer();
            }
        }
        else
        {
            //Face DOWN
            if (m_TopLayer)
            {
                ChangeLayer();
            }
        }
    }
    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;
        transform.Rotate(0f, 180f, 0f);
    }
    private void ChangeLayer()
    {
        /*
        if (!m_TopLayer)
        {
            spriteRenderer.sortingOrder = 11;
        }
        else
        {
            spriteRenderer.sortingOrder = 5;
        }
        m_TopLayer = !m_TopLayer;*/
    }
    public void DeathAnimation()
    {
        isDissolving = true;
    }
}
