using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RandomizeAnswer : MonoBehaviour
{
    //[SerializeField] private int _maxOnScreen = 5;
    [SerializeField] private List<GameObject> _answers = new List<GameObject>();

    //[SerializeField] private List<GameObject> _answerKeys = new List<GameObject>();
    //[SerializeField] private GameObject _answerKeyHolder;

    private void Start()
    {

        for (int i = 0; i < _answers.Count; i++)
        {
            var r = Random.Range(i, _answers.Count);
            var temp = _answers[i];
            _answers[i] = _answers[r];
            _answers[r] = temp;
            Debug.Log(i);
            Instantiate(_answers[i], transform);
            
        }

        //SpawnCharacters();
    }


    /*private void SpawnCharacters()
    {

        for (int i = 0; i < _maxOnScreen; i++)
        {
            int RNG = Random.Range(0, _answers.Count);
            Debug.Log(RNG);
            Instantiate(_answers[RNG], transform);
            Instantiate(_answerKeys[RNG], _answerKeyHolder.transform);

        }
    }*/
}
