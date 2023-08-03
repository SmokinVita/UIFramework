using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadProfileList : MonoBehaviour
{
    [SerializeField] private GameObject _profileTemplate;
    [SerializeField] private TMP_Text _text;

    private void OnEnable()
    {
        foreach (var profile in GameManager.Instance.GetAllProfiles())
        {
            GameObject currentList = Instantiate(_profileTemplate, transform);
            currentList.GetComponentInChildren<TMP_Text>().SetText(profile);
        }
    }
}
