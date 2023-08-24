using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ProfileName : MonoBehaviour, IPointerClickHandler
{

    public int index;

    public void OnPointerClick(PointerEventData eventData)
    {
        UIManager.Instance.LoadProfile(index);
    }
}
