using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectContainer : MonoBehaviour
{
    public bool isFull;
    public game_manager manager;
    public Image backgroundImage;

    public void Start()
    {
        manager = game_manager.instance;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (manager.draggingObject != null && isFull == false)
        {
            manager.currentContainer = this.gameObject;
            backgroundImage.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        manager.currentContainer = null;
        backgroundImage.enabled = false;
    }
}
