using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Drop : MonoBehaviour, IDropHandler
{

    [SerializeField] private DragAndDropGame _game;
    [SerializeField] private string _hiraganaNeeded;
    private Image _image;

    // Start is called before the first frame update
    void Start()
    {
        _image = GetComponent<Image>();
        _game = GameObject.Find("GameBehaviour").GetComponent<DragAndDropGame>();
        if (_game == null)
            Debug.LogError("DragAndDropGame is NULL!");
    }
    
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag.name == _hiraganaNeeded)
        {
            eventData.pointerDrag.GetComponent<Drag>()._startPOS = _image.rectTransform.position;
            eventData.pointerDrag.GetComponent<Drag>()._isInCorrectAnswer = true;
            _game.Points(3, false);
            _game.CorrectSelection();
            AudioManager.Instance.PlayCorrectSound();
        }
        else
        {
            _game.Points(-2, true);
            AudioManager.Instance.PlayIncorrectSound();
        }
    }
}
