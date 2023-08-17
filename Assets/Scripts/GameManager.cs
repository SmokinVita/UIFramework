using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("GameManager is NULL");

            return _instance;
        }

    }

    private List<string> _profiles = new List<string>();
    [SerializeField] private string _currentProfile;

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

    public void CreateProfile(string profile)
    {
        PlayerPrefs.SetString(profile, profile);
        _profiles.Add(profile);
        _currentProfile = profile;
    }

    public void LoadProfile(string profile)
    {
        PlayerPrefs.GetString(profile, profile);
        _currentProfile = profile;
    }

    public List<string> GetAllProfiles()
    {
        return _profiles;
    }

    public string ReturnCurrentProfile()
    {
        return _currentProfile;
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadScene(int sceneId)
    {
        SceneManager.LoadScene(sceneId);
    }

    public void QuitGame()
    {
        if (Application.isEditor)
        {
            Debug.Log("Tried to quit game in Editor!!");
        }
        else
            Application.Quit();
    }
}
