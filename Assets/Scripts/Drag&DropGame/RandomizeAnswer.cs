using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeAnswer : MonoBehaviour
{

    [SerializeField] private List<GameObject> _answers = new List<GameObject>();

    private void Start()
    {
        for (int i = 0; i < _answers.Count; i++)
        {
            var r = Random.Range(i, _answers.Count);
            var temp = _answers[i];
            _answers[i] = _answers[r];
            _answers[r] = temp;
            Instantiate(_answers[i], transform);
        }
    }
}
