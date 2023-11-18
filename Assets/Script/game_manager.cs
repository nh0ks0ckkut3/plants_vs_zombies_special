using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game_manager : MonoBehaviour
{
    public GameObject draggingObject;
    public GameObject currentContainer;

    public static game_manager instance;
    public bool isStart = false;
    public bool[] slotX = { false, false, false, false, false, false, false, false };
    private void Awake()
    {
        instance = this;
    }

    public void placeObject()
    {
        if (draggingObject != null && currentContainer != null)
        {
            
            GameObject gameObject = draggingObject.GetComponent<Object_Dragging>().card.object_Game;
            
            Instantiate(gameObject, currentContainer.transform);
            // Đảm bảo đối tượng mới tạo nằm trên cùng lớp render
            gameObject.transform.SetAsLastSibling();
            gameObject.transform.position = new Vector3(0, 0.2f, currentContainer.transform.position.z);


            //Debug.Log(currentContainer.transform.position);
            //Debug.Log(currentContainer.transform.localPosition);
            //Debug.Log(gameObject.transform.position);
            //Debug.Log(gameObject.transform.localPosition);
            currentContainer.GetComponent<ObjectContainer>().isFull = true;
        }
    }
    
}
