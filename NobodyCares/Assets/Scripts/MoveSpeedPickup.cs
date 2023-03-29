using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MoveSpeedPickup : PickUp
{
    public string upgradeText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerMovement>().moveSpeed++;
            FindObjectOfType<PickUpTextHandler>().PopUpText(upgradeText);
            FindObjectOfType<AudioManager>().PlaySound("PickUp");
            Destroy(gameObject);
        }
    }
    public override void PickUpItem()
    {
        base.PickUpItem();

        Destroy(gameObject);
    }
}
