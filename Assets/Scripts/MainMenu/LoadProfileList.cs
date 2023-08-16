using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadProfileList : MonoBehaviour
{
    [SerializeField] private GameObject _profileTemplate;
    [SerializeField] private TMP_Text _text;

    private void Start()
    {
        foreach (var profile in GameManager.Instance.GetAllProfiles())
        {
            CreatedProfile(profile);
        }
    }

    public void CreatedProfile(string profileName)
    {
        GameObject currentList = Instantiate(_profileTemplate, transform);
        currentList.GetComponentInChildren<TMP_Text>().SetText(profileName);
    }

}
