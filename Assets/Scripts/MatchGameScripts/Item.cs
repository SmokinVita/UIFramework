using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Item : MonoBehaviour, IPointerDownHandler
{

    [SerializeField] private int _itemID;
    [SerializeField] private Image _coverImage;
    [SerializeField] private MatchItem _itemMatch;

    // Start is called before the first frame update
    void Start()
    {
        _itemMatch = GameObject.Find("GameBehaviour").GetComponent<MatchItem>();
        if (_itemMatch == null)
            Debug.LogError("MatchItem is null");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int ReturnItemID()
    {
        return _itemID;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _itemMatch.Match(this.gameObject);
        UncoverItem();
    }

    private void UncoverItem()
    {
        _coverImage.gameObject.SetActive(false);
    }

    public void CoverItem(bool matched)
    {
        if (matched == false)
            _coverImage.gameObject.SetActive(true);
    }
}
