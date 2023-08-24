using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadProfileList : MonoBehaviour
{
    [SerializeField] private GameObject _profileTemplate;
    [SerializeField] private TMP_Text _text;
    private int _index;

    public void GameStarted()
    {
        foreach (var profile in GameManager.Instance.GetAllProfiles())
        {
            CreatedProfileList(profile);
        }
    }

    public void CreatedProfileList(string profileName)
    {
        GameObject currentList = Instantiate(_profileTemplate, transform);
        currentList.GetComponentInChildren<TMP_Text>().SetText(profileName);
        currentList.GetComponent<ProfileName>().index = _index;
        _index++;
    }

}
