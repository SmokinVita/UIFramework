using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class Drag : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private TMP_Text _text;
    [SerializeField] public Vector3 _startPOS;
    public bool _isInCorrectAnswer = false;

    // Start is called before the first frame update
    void Start()
    {
        _text = GetComponent<TMP_Text>();
        _startPOS = _text.rectTransform.position;
    }

    private void ResetPosition()
    {
        _text.rectTransform.position = _startPOS;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        var tempColor = _text.color;
        tempColor.a = .5f;
        _text.color = tempColor;
        _text.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        ResetPosition();
        var tempColor = _text.color;
        tempColor.a = 1f;
        _text.color = tempColor;

        if (_isInCorrectAnswer == true)
            _text.raycastTarget = false;
        else
            _text.raycastTarget = true;
    }
}
