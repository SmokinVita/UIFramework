using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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

    [SerializeField] private TMP_Text _timeText;
    private float _seconds;
    private int _minuteCounter, _hourCounter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Timer();
    }

    private void Timer()
    {
        _seconds += Time.deltaTime;
        _timeText.SetText($"{_minuteCounter}:{(int)_seconds}");
        if (_seconds > 60f)
        {
            _minuteCounter++;
            _seconds = 0;
        }
    }
}
