using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FollowMousePopup : MonoBehaviour
{
    


    private void LateUpdate()
    {
        transform.position = Input.mousePosition;
    }
}
