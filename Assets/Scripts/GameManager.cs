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
    private int _currentProfileIndex;

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

    private void Start()
    {
        _currentProfileIndex = PlayerPrefs.GetInt("CurrentAmountOfProfiles");
        for (int i = 0; i < _currentProfileIndex; i++)
        {
            if (PlayerPrefs.HasKey($"ProfileName{i}") == true)
            {
                _profiles.Add(PlayerPrefs.GetString($"ProfileName{i}"));
            }
        }
    }

    public void CreateProfile(string profile)
    {
        PlayerPrefs.SetString($"ProfileName{_currentProfileIndex}", profile);
        PlayerPrefs.Save();
        _currentProfile = PlayerPrefs.GetString($"ProfileName{_currentProfileIndex}");
        _currentProfileIndex++;
        
    }

    public void LoadProfile(int selectedIndex)
    {
        _currentProfile = PlayerPrefs.GetString($"ProfileName{selectedIndex}");
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
            PlayerPrefs.SetInt("CurrentAmountOfProfiles", _currentProfileIndex);
        }
        else
        {
            PlayerPrefs.SetInt("CurrentAmountOfProfiles", _currentProfileIndex);
            Application.Quit();
        }
    }
}
