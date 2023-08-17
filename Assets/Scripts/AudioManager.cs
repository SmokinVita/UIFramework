using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    [SerializeField] private AudioClip _incorrectClip;
    [SerializeField] private AudioClip _correctClip;
    [SerializeField] private AudioClip[] _buttonSelectionClips;

    private void Awake()
    {
        if (_instance == null)
        {
            DontDestroyOnLoad(this);
            _instance = this;
        }

        if (_instance != this)
        {
            Destroy(this.gameObject);
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

    public void PlayIncorrectSound()
    {
        _audioSource.clip = _incorrectClip;
        _audioSource.Play();
    }

    public void PlayCorrectSound()
    {
        _audioSource.clip = _correctClip;
        _audioSource.Play();
    }

    public void ButtonSelectionSound()
    {
        var randomSound = Random.Range(0, _buttonSelectionClips.Length);
        _audioSource.clip = _buttonSelectionClips[randomSound];
        _audioSource.Play();
    }

}
