using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("UI Manager Instance is NULL!");

            return _instance;
        }
    }
    [SerializeField] private GameObject _titlePage;

    [SerializeField] private GameObject _gameSelectionMenu;
    [SerializeField] private TMP_Text _debugText;

    [SerializeField] private TMP_InputField _inputField;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private string _selectedProfile;
    [SerializeField] private TMP_Text _profileDebugText;
    [SerializeField] private GameObject _profileSelectionPage;
    [SerializeField] private GameObject _profilePage;
    [SerializeField] private GameObject _profileListPage;
    [SerializeField] private LoadProfileList _loadProfileList;

    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private Slider _sfxSlider;
    [SerializeField] private Slider _musicSlider;

    private void Awake()
    {
        _instance = this;
        
    }

    // Start is called before the first frame update
    void Start()
    {
        _profileDebugText.SetText("");
        _loadProfileList.GameStarted();
    }

    public void LoadGameSelectionMenu()
    {
        if (GameManager.Instance.ReturnCurrentProfile() == "")
        {
            _debugText.gameObject.SetActive(true);
            return;
        }
        else
        {
            _gameSelectionMenu.SetActive(true);
        }
    }



    public void SFXVolume()
    {
        _audioMixer.SetFloat("SFXMixer", _sfxSlider.value);
    }

    public void MusicVolume()
    {
        _audioMixer.SetFloat("MusicMixer", _musicSlider.value);
    }

    public void CreateProfile()
    {
        //go through profile list and verify new profile doesn't already exist
        foreach (var item in GameManager.Instance.GetAllProfiles())
        {
            if (_inputField.text == item)
            {
                _profileDebugText.SetText("Profile Already Exist! Create another please!");
                _profileDebugText.text = "";
                return;
            }
        }

        //verifies profile name is longer than 2 characters
        if (_inputField.text.Length < 3)
        {
            _profileDebugText.SetText("Please create a profile with more than three Characters!");
            _inputField.text = "";
            return;
        }

        //Calls Gamemanager Create Profile, add's profile name to Load Profile page. Clear's out inputfield text. 
        GameManager.Instance.CreateProfile(_inputField.text);
        _loadProfileList.CreatedProfileList(_inputField.text);
        _inputField.text = "";
        
        //clear's out debug text, than disables Profile Page and activates Title Page
        _profileDebugText.SetText("");
        _profileSelectionPage.SetActive(false);
        _titlePage.SetActive(true);
    }

    public void LoadProfile(int selectedIndex)
    {
        GameManager.Instance.LoadProfile(selectedIndex);
        _profileSelectionPage.SetActive(false);
        _profileListPage.SetActive(false);
        _profilePage.SetActive(true);
        _titlePage.SetActive(true);
    }

    
}
