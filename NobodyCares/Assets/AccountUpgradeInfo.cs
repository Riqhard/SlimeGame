using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AccountUpgradeInfo : MonoBehaviour
{


    public GameObject popupGameobject;

    public void OnPointerEnter(PointerEventData eventData)
    {
        popupGameobject.SetActive(true);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        popupGameobject.SetActive(false);
    }
}
