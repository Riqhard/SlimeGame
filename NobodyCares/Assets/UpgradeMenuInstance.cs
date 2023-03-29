using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeMenuInstance : MonoBehaviour
{


    public static UpgradeMenuInstance instance;

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
