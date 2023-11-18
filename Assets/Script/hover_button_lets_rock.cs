using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class hover_button_lets_rock : MonoBehaviour
{
    public TextMeshProUGUI buttonLetsRock;
    private GameObject btn;

    public void Start()
    {
        btn = buttonLetsRock.transform.parent.gameObject;
    }

    private void OnMouseOver()
    {
        if (!btn.activeSelf)
        {
            btn.SetActive(true);
        }
    }

    private void OnMouseExit()
    {
        if (btn.activeSelf)
        {
            btn.SetActive(false);
        }
    }
}
