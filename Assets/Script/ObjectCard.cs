using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Xml.Linq;

public class ObjectCard : MonoBehaviour,  IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    public GameObject object_Drag;
    public GameObject object_Game;
    public GameObject object_Card_Select;
    public Canvas canvas;
    private GameObject objectDragInstance;

    private Transform objectDragTransform;
    private CanvasGroup canvasGroup;

    private game_manager gameManager;

    private float[] potitionsX = { -4.86f, -3.9f, -2.93f, -1.953f, -0.975f, 0f, 0.986f, 1.97f };
    private Vector3 potition_Storage;
    private int index_queue = -1;
    private float potitionY = 3.21f;
    private bool isStart;
    public float cooldown;
    private bool isReadyToBuy = true;
    private Image image;
    public int cost;

    public void Start()
    {
        gameManager = game_manager.instance;
        potition_Storage = transform.position;
        image = GetComponent<Image>();
    }
    public void Update()
    {
        isStart = gameManager.isStart;
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Cập nhật vị trí của objectDragInstance theo vị trí con trỏ chuột
        if (isStart && isReadyToBuy && cost <= gameManager.suns) {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;
            if (objectDragInstance != null)
            {

                objectDragTransform.position = mousePosition;
            }
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (isStart && isReadyToBuy && cost <= gameManager.suns)
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

    }
    //objectDragInstance.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

    //objectDragInstance = Instantiate(object_Drag,new Vector3(-8, 0, 0), Quaternion.identity);

    public void OnPointerUp(PointerEventData eventData)
    {
        if (isStart && isReadyToBuy && cost <= gameManager.suns)
        {
            gameManager.placeObject();
            gameManager.draggingObject = null;
            Destroy(objectDragInstance);
            if (isReadyToBuy)
            {
                isReadyToBuy = false;
                image.color = new Color(0.85f, 0.85f, 0.85f, 0.186f);
                gameManager.suns -= cost;
                Invoke("coolDown", cooldown);
            }
            
        }
        else if (!isStart)
        {
            GameObject getObjectParent;
            if (transform.parent.gameObject.name == "ListCard")
            {
                getObjectParent = transform.parent.gameObject.transform.parent.gameObject.transform.Find("chooseyourplant").gameObject;
                gameManager.slotX[index_queue] = false;
                transform.position = potition_Storage;
                transform.SetParent(getObjectParent.transform);
               
            }
            else
            {
                float xTarget = -5;
                
                for (int i = 0; i < potitionsX.Length; i++)
                {
                    if (!gameManager.slotX[i])
                    {
                        xTarget = potitionsX[i];
                        gameManager.slotX[i] = true;
                        index_queue = i;
                        break;
                    }
                }
                if (xTarget > -5)
                {
                    //GameObject spawnedObject = Instantiate(object_Card_Select, new Vector3(xTarget, potitionY, 0), Quaternion.identity);
                    getObjectParent = transform.parent.gameObject.transform.parent.gameObject.transform.Find("ListCard").gameObject;
                    //spawnedObject.transform.SetParent(getObjectParent.transform);
                    //spawnedObject.transform.localScale = new Vector3(0.81438f, 0.81438f, 0.81438f);
                    //spawnedObject.transform.SetSiblingIndex(newIndex);
                    transform.position = new Vector3(xTarget, potitionY, 0);
                    transform.SetParent(getObjectParent.transform);

                }
            }
            
        }
        
    }
    private void coolDown()
    {
        isReadyToBuy = true;
        image.color = new Color(1, 1, 1, 1);
    }

}
