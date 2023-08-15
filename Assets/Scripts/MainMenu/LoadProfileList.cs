using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadProfileList : MonoBehaviour
{
    [SerializeField] private GameObject _profileTemplate;
    [SerializeField] private TMP_Text _text;

    public void CreatedProfile(string profileName)
    {
        GameObject currentList = Instantiate(_profileTemplate, transform);
        currentList.GetComponentInChildren<TMP_Text>().SetText(profileName);
    }

}
