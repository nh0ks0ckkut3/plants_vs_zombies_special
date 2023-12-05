using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ClickToStart : MonoBehaviour
{
    // Start is called before the first frame update
    private game_manager gameManager;
    void Start()
    {
        gameManager = game_manager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void clickToStart()
    {
        GameObject getObject_chooseplant = transform.parent.gameObject.transform.Find("chooseyourplant").gameObject;
        getObject_chooseplant.SetActive(false);
        gameManager.isStart = true;
        gameManager.SpawnSun();
        gameManager.sound_start.Play();
        Destroy(gameObject);
    }
}
