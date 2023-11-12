using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectCard : MonoBehaviour,  IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    public GameObject object_Drag;
    public GameObject object_Game;
    public Canvas canvas;
    private GameObject objectDragInstance;

    private Transform objectDragTransform;
    private CanvasGroup canvasGroup;

    private game_manager gameManager;

    public void Start()
    {
        gameManager = game_manager.instance;
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Cập nhật vị trí của objectDragInstance theo vị trí con trỏ chuột
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        objectDragTransform.position = mousePosition;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        objectDragInstance = Instantiate(object_Drag, Vector3.zero, Quaternion.identity);
        objectDragTransform = objectDragInstance.GetComponent<Transform>();
        canvasGroup = objectDragInstance.AddComponent<CanvasGroup>();

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0; // Đảm bảo đối tượng nằm trong mặt phẳng XY

       

        // Đặt vị trí của objectDragInstance tại vị trí con trỏ chuột
        objectDragInstance.transform.position = mousePosition;

        //
        objectDragInstance.GetComponent<Object_Dragging>().card = this;

        // Đảm bảo đối tượng mới tạo nằm trên cùng lớp render
        objectDragInstance.transform.SetAsLastSibling();
        
         // Kích hoạt tính năng tương tác sau khi kéo đối tượng
        canvasGroup.blocksRaycasts = true;

        //Debug.Log("" + mousePosition + " " + objectDragInstance.transform);
        gameManager.draggingObject = objectDragInstance;

    }
    //objectDragInstance.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

    //objectDragInstance = Instantiate(object_Drag,new Vector3(-8, 0, 0), Quaternion.identity);

    public void OnPointerUp(PointerEventData eventData)
    {
        gameManager.placeObject();
        gameManager.draggingObject = null;
        Destroy(objectDragInstance);
        
    }
}
