using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DragAndDropGame : MonoBehaviour
{

    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private int _score = 0;
    private int _correctAmount;

    private void Start()
    {
        _scoreText.SetText(_score.ToString());
    }

    public void Points(int points)
    {
        _score += points;
        _scoreText.SetText(_score.ToString());
    }

    public void CorrectSelection()
    {
        _correctAmount++;
        if(_correctAmount == 5)
        {
            Debug.Log("You Won!");
        }
    }
}
