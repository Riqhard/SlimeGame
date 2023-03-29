using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ChickenLeg : PickUp
{

    int healthToGive = 100;
    public string upgradeText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Player>().HealDamage(healthToGive);
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
