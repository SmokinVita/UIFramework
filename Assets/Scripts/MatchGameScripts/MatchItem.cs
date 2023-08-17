using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MatchItem : MonoBehaviour
{
    [Header("MatchItems Variables!")]
    [SerializeField] private GameObject _item1;
    [SerializeField] private GameObject _item2;
    [SerializeField] private int _matchedItems;


    //Timer
    [Header("Variables for Timer")]
    [SerializeField] private TMP_Text _timerText;
    [SerializeField] private ItemSpawn _itemSpawner;
    [SerializeField] private float _finalTime;
    private bool _isTimerActive = false;
    private float _seconds;
    private int _minutes;
    private bool _openedWinScene = false;


    //WinScreen
    [Header("Win Screen Settings!")]
    [SerializeField] private TMP_Text _finalTimeText;
    [SerializeField] private TMP_Text _quickestTimeText;
    [SerializeField] private GameObject _winScreen;
    [SerializeField] private float _fastestTime;


    private void Start()
    {
        _openedWinScene = false;
        _isTimerActive = true;
        if (_itemSpawner == null)
        {
            Debug.LogError("Item Spawn is NULL!");
        }

    }

    private void Update()
    {
        Timer();
    }

    public void Match(GameObject gameObject)
    {
        //Set selected object to Item slot for comparison.
        if (_item1 == null)
        {
            _item1 = gameObject;
        }
        else
        {
            _item2 = gameObject;
        }

        if (_item1 == null || _item2 == null)
        {
            return;
        }

        if (_item1.name == _item2.name)
        {
            _item1 = null;
            _item2 = null;

            AudioManager.Instance.PlayCorrectSound();
            _matchedItems++;
            if (_matchedItems == _itemSpawner.PairsToWin())
            {
                _isTimerActive = false;

            }
        }
        else if (_item1.name != _item2.name)
        {
            StartCoroutine(CoverRoutine());
            AudioManager.Instance.PlayIncorrectSound();
        }
    }

    public void Timer()
    {
        if (_isTimerActive == false)
        {
            _finalTime = _minutes + _seconds;
            if (_openedWinScene == false)
            {
                _openedWinScene = true;
                GameWon();
            }
            return;
        }

        _seconds += Time.deltaTime;

        _timerText.SetText($"{(int)_seconds}");

    }

    private void GameWon()
    {

        _winScreen.SetActive(true);
        _finalTimeText.SetText($"{(int)_seconds}");

        _fastestTime = PlayerPrefs.GetFloat(GameManager.Instance.ReturnCurrentProfile() + "FastestTime");


        if (_finalTime < _fastestTime || _fastestTime == 0)
        {
            PlayerPrefs.SetFloat(GameManager.Instance.ReturnCurrentProfile() + "FastestTime", _finalTime);
            Debug.Log(PlayerPrefs.GetFloat(GameManager.Instance.ReturnCurrentProfile() + "FastestTime"));
            _quickestTimeText.SetText($"{(int)_finalTime}");
        }
        else
        {
            Debug.Log("Not Quicker");
            _quickestTimeText.SetText($"{(int)_fastestTime}");
        }
    }

    IEnumerator CoverRoutine()
    {
        yield return new WaitForSeconds(.2f);
        _item1.GetComponent<Item>().CoverItem(false);
        yield return new WaitForEndOfFrame();
        _item2.GetComponent<Item>().CoverItem(false);
        _item1 = null;
        _item2 = null;
    }
}
