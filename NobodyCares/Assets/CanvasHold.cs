using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasHold : MonoBehaviour
{
    public static CanvasHold instance;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

 
}
