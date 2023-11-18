using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class CardManager : MonoBehaviour, IDragHandler, IDropHandler, IPointerUpHandler
{
    public Texture dragging;
    public void OnDrag(PointerEventData eventData)
    {
        //take a game object
    }

    public void OnDrop(PointerEventData eventData)
    {
        //place the gameobject
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //remove the gameobject
    }
}
