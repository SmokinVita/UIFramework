using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
    [SerializeField] private List<GameObject> _itemPrefabs = new List<GameObject>();
    [SerializeField] private List<GameObject> _spawnedItem = new List<GameObject>();
    [SerializeField] private int _spawn0Count, _spawn1Count, _spawn2Count, _spawn3Count, _randomInt;

    // Start is called before the first frame update
    void Start()
    {
        SpawnItems();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
            SpawnItems();
    }

    private void SpawnItems()
    {
        for (int i = 0; i < 16; i++)
        {
        _randomInt = Random.Range(0, _itemPrefabs.Count);
        GameObject item = Instantiate(_itemPrefabs[_randomInt]);
        item.transform.SetParent(transform);

        int currentId = item.GetComponent<Item>().ReturnItemID();
      
            if (currentId == 0)
            {
                _spawn0Count++;
                if (_spawn0Count == 4)
                    _itemPrefabs.RemoveAt(_randomInt);
            }
            else if (currentId == 1)
            {
                _spawn1Count++;
                if (_spawn1Count == 4)
                    _itemPrefabs.RemoveAt(_randomInt);
            }
            else if (currentId == 2)
            {
                _spawn2Count++;
                if (_spawn2Count == 4)
                    _itemPrefabs.RemoveAt(_randomInt);
            }
            else if (currentId == 3)
            {
                _spawn3Count++;
                if (_spawn3Count == 4)
                    _itemPrefabs.RemoveAt(_randomInt);
            }
        }
    }

    /*private void CheckForDuplicates()
    {

        switch (item.GetComponent<Item>().ReturnItemID())
        {
            case 0:

                break;
            case 1:
                _spawn1Count++;
                if (_spawn1Count == 4)
                    _itemPrefabs.RemoveAt(1);
                break;
            case 2:
                _spawn2Count++;
                if (_spawn2Count == 4)
                    _itemPrefabs.RemoveAt(2);
                break;
            case 3:
                _spawn3Count++;
                if (_spawn3Count == 4)
                    _itemPrefabs.RemoveAt(3);
                break;
        }
    }*/
}

