using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{

    [SerializeField] private int _itemID;
    [SerializeField] private Image _coverImage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int ReturnItemID()
    {
        return _itemID;
    }

    
}
