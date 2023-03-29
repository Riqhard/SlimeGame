using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    
    public Camera cam;


    Vector2 mousePos;

    public bool usingThis;
    
    private void Update()
    {
        if (usingThis)
        {
            mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

            Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            difference.Normalize();

            float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotZ);
        }
    }

    public void Flip()
    {
        transform.Rotate(0f, 180f, 0f);
    }
}
