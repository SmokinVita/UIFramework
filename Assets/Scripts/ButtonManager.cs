using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{

    [SerializeField] private Button[] _buttons;
    [SerializeField] private Button[] _closeButton;
    [SerializeField] private Button _quitGameButton;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }


    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        //_settingButton.onClick.AddListener(() => { AudioManager.Instance.ButtonSelectionSound(); });
        foreach (var button in _closeButton)
        {
            button.onClick.AddListener(() => { AudioManager.Instance.PlayClosePanelSound(); });
        }


        foreach (var button in _buttons)
        {
            button.onClick.AddListener(() => { AudioManager.Instance.ButtonSelectionSound(); });
        }

        _quitGameButton.onClick.AddListener(() => { GameManager.Instance.QuitGame(); });
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
