using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance;
    public static AudioManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.Log("AudioManager is NULL!");

            return _instance;
        }
    }

    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _pageCloseClip;
    [SerializeField] private AudioClip _selectClip;

    private void Awake()
    {
        if (_instance == null)
        {
            DontDestroyOnLoad(this);
            _instance = this;
        }

        if (_instance != this)
        {
            Destroy(this);
        }
    }

    public void PlayClosePanelSound()
    {
        _audioSource.clip = _pageCloseClip;
        _audioSource.Play();
    }

    public void PlaySelectClip()
    {
        _audioSource.clip = _selectClip;
        _audioSource.Play();
    }

}
