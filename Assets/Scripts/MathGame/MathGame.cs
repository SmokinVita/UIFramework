using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MathGame : MonoBehaviour
{

    [SerializeField] private TMP_Text _question1Text, _question2Text, _answerText;
    [SerializeField] private TMP_InputField _input;
    private int _number1, _number2, _correctAnswer, _playerAnswer;

    [SerializeField] private TMP_Text _scoreText, _debugText;
    [SerializeField] private int _maxAnswers;
    [SerializeField] private Button _nextAnswerButton, _checkAnswerButton;
    private int _amountOfQuestions, _score;


    [SerializeField] private int _finalScore, _highscore;
    [SerializeField] private TMP_Text _finalScoreText, _highscoreText;
    [SerializeField] private GameObject _gameOverPage;

    // Start is called before the first frame update
    void Start()
    {
        CreateQuestion();
        _scoreText.SetText(_score.ToString());
        _debugText.gameObject.SetActive(false);
        _gameOverPage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateQuestion()
    {
        _number1 = Random.Range(1, 6);
        _question1Text.SetText(_number1.ToString());
        _number2 = Random.Range(1, 6);
        _question2Text.SetText(_number2.ToString());

        _answerText.SetText("");
        _correctAnswer = _number1 + _number2;

        _input.text = "";
        _input.readOnly = false;

        _checkAnswerButton.interactable = true;
    }

    public void CheckAnswer()
    {
        if(_input.text == "")
        {
            _debugText.gameObject.SetActive(true);
            return;
        }

        _debugText.gameObject.SetActive(false);
        _input.readOnly = true;

        _checkAnswerButton.interactable = false;
        _playerAnswer = int.Parse(_input.text.ToString());
        if (_playerAnswer == _correctAnswer)
        {
            _answerText.SetText(_playerAnswer.ToString());
            _score += 5;
            AudioManager.Instance.PlayCorrectSound();
        }
        else
        {
            _answerText.SetText(_correctAnswer.ToString());
            _answerText.color = new Color(200,0, 0);
            _score -= 3;
            AudioManager.Instance.PlayIncorrectSound();
        }

        _scoreText.SetText(_score.ToString());
        _amountOfQuestions++;
        if (_amountOfQuestions == _maxAnswers)
        {
            _nextAnswerButton.interactable = false;
            _finalScore = _score;
            GameOver();
        }
    }

    private void GameOver()
    {
        _highscore = PlayerPrefs.GetInt(GameManager.Instance.ReturnCurrentProfile() + "MathHighScore");

        _gameOverPage.SetActive(true);
        _finalScoreText.SetText(_finalScore.ToString());

        if(_finalScore >  _highscore)
        {
            _highscoreText.SetText(_finalScore.ToString());
            PlayerPrefs.SetInt(GameManager.Instance.ReturnCurrentProfile() + "MathHighScore", _finalScore);
        }
        else
        {
            _highscoreText.SetText(_highscoreText.ToString());
        }
    }

}
