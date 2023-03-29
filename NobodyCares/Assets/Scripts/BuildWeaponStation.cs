using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildWeaponStation : MonoBehaviour
{

    public Transform player;
    public float rangeToInteract;
    bool buildingButtonsShow;
    bool showingCostUI;
    bool stationBuild = false;
    public int costToUpgrade;
    public GameObject costUi;
    public TMPro.TextMeshProUGUI coinText;
    PlayerUI playerUI;
    Animator animator;

    

    private void Start()
    {
        playerUI = FindObjectOfType<PlayerUI>();
        animator = costUi.GetComponent<Animator>();

    }

    public void Update()
    {
        float distance = Vector2.Distance(player.position, transform.position);

        if (distance <= rangeToInteract)
        {
            costUi.SetActive(true);
            showingCostUI = true;
            coinText.text = "" + costToUpgrade;
        }
        else if (distance > rangeToInteract && showingCostUI)
        {
            costUi.SetActive(false);
            showingCostUI = false;
        }


    }
    

}
