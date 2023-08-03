using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
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
    [SerializeField] private Scrollbar _scrollBar;
    [SerializeField] private TMP_InputField _inputField;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private string _selectedProfile;


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

    public void AdjustSliderToRight()
    {
        _scrollBar.value += .5f;
        
    }

    public void AdjustLeft()
    {
        _scrollBar.value -= .5f;

        if (_scrollBar.value < 0)
        {
            _scrollBar.value = .1f;
        }
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
