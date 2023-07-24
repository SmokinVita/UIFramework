using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MatchItem : MonoBehaviour
{
    [SerializeField] private GameObject _item1, _item2;

    public void Match(GameObject gameObject)
    {
        if (_item1 == null)
        {
            _item1 = gameObject;
        }
        else
        {
            _item2 = gameObject;
        }

        if (_item1 == null || _item2 == null)
        {
            return;
        }

        if (_item1.tag == _item2.tag)
        {
            Debug.Log("Matched!!");
            //GameManager.GetTime
            //M

            _item1 = null;
            _item2=null;
        }
        else if (_item1.tag != _item2.tag)
        {
            Debug.Log("Did not match!!");
            StartCoroutine(CoverRoutine());
        }

    }

    IEnumerator CoverRoutine()
    {
        yield return new WaitForSeconds(.5f);
        _item1.GetComponent<Item>().CoverItem(false);
        yield return new WaitForEndOfFrame();
        _item2.GetComponent <Item>().CoverItem(false);
        _item1= null;
        _item2=null;
    }

    
}
