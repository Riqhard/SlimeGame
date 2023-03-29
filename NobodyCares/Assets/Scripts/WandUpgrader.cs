using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WandUpgrader : MonoBehaviour
{
    Transform player;
    public float rangeToInteract;
    bool buildingButtonsShow;
    bool showingUIButton;
    public GameObject UIButton;

    public GameObject wandUpgradeMenu;
    public void Start()
    {
        player = FindObjectOfType<Player>().transform;
    }

    void Update()
    {
        float distance = Vector2.Distance(player.position, transform.position);

        if (distance <= rangeToInteract)
        {
            UIButton.SetActive(true);
            showingUIButton = true;
        }
        else if (distance > rangeToInteract && showingUIButton)
        {
            UIButton.SetActive(false);
            showingUIButton = false;
        }
        if (Input.GetKeyDown(KeyCode.E) && showingUIButton)
        {
            ToggleWandUpgradeMenu();
        }
    }
    public void ToggleWandUpgradeMenu()
    {
        // Toggle Pause Game

        // Toggle player movement and shooting

        // Toggle wandupgrade menu
        wandUpgradeMenu.SetActive(!wandUpgradeMenu.activeSelf);
    }
}
