using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickToDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnPointerUp(PointerEventData eventData)
    {
        Destroy(gameObject);
    }
}
