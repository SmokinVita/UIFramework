using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MatchItem : MonoBehaviour, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log(eventData.pointerClick.name);
        //eventData.pointerClick.GetComponent<Item>().ReturnItemID();
    }
}
