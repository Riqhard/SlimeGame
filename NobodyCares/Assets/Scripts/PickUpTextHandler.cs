using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PickUpTextHandler : MonoBehaviour
{
    public TextMeshProUGUI proUGUI;
    public Animator textAnimator;

    // Start is called before the first frame update
    void Start()
    {
        proUGUI.text = "";
    }

    public void PopUpText(string sentText)
    {
        proUGUI.text = sentText;
        textAnimator.SetTrigger("Pop");
    }
}
