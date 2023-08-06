using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DragAndDropGame : MonoBehaviour
{
    [SerializeField] private GameObject _winScene;
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private int _score = 0;
    private int _correctAmount;
    private int _comboAmount;


    [SerializeField] private TMP_Text _finalScoreText;
    [SerializeField] private TMP_Text _highscoreText;
    [SerializeField] private int _highscore;

    private void Start()
    {
        _scoreText.SetText(_score.ToString());
    }

    public void Points(int points, bool madeMistake)
    {
        if (madeMistake)
        {
            _comboAmount = 0;
        }
        else if (!madeMistake)
        {
            _comboAmount++;
            points = points *_comboAmount;
        }

        _score += points;
        _scoreText.SetText(_score.ToString());
    }

    public void CorrectSelection()
    {
        _correctAmount++;
        if (_correctAmount == 5)
        {
            WinScene();
            _winScene.SetActive(true);
        }
    }

    public void WinScene()
    {
        _highscore = PlayerPrefs.GetInt(GameManager.Instance.ReturnCurrentProfile() + "DragHighScore");
        _finalScoreText.SetText(_score.ToString());
        if (_score > _highscore)
        {
            PlayerPrefs.SetInt(GameManager.Instance.ReturnCurrentProfile() + "DragHighScore", _score);
            _highscoreText.SetText(_score.ToString());
        }
        else
        {
            _highscoreText.SetText(_highscore.ToString());
        }
    }
}
