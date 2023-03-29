using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartNextNight : MonoBehaviour
{
    Transform player;
    float rangeToInteract = 2f;

    public GameObject thisUI;
    bool isActive;
    public bool isDay = true;


    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(player.position, transform.position);
        if (distance <= rangeToInteract && isDay)
        {
            thisUI.SetActive(true);
            isActive = true;
        }
        else if (isActive && distance > rangeToInteract)
        {
            thisUI.SetActive(false);
        }
        if (isActive && Input.GetKeyDown(KeyCode.E))
        {
            thisUI.SetActive(false);
            isActive = false;
            isDay = false;
            NextNight();
        }
    }

    public void NextNight()
    {
        FindObjectOfType<_GameManager>().ChangeToNightTime();
    }
}
