using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.Audio;

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
    [SerializeField] private TMP_InputField _inputField;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private string _selectedProfile;

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
        
    }

    // Update is called once per frame
    void Update()
    {

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
        GameManager.Instance.CreateProfile(_inputField.text);
        Debug.Log($"New Profile " + _inputField.text);
    }

    public void LoadProfile(GameObject profile)
    {
        Debug.Log(profile.name);
        GameManager.Instance.LoadProfile(profile.GetComponentInChildren<TMP_Text>().text);
    }
}
