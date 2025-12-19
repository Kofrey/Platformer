using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class SmoothBar : HealthUpdater
{
    [SerializeField] private float _maxDelta = 0.03f;

    private Coroutine _coroutine;

    private void Start()
    {
        _slider.value = _health.Max;
    }

    protected override void SetValues(int health)
    {
        if(_coroutine == null)
        {
            _coroutine = StartCoroutine(SetValueSmooth(health));
        }
        else
        {
            StopCoroutine(_coroutine);
            _coroutine = StartCoroutine(SetValueSmooth(health));
        }   
    }

    private IEnumerator SetValueSmooth(int value)
    {
        while(_slider.value != value)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, value, _maxDelta);
            yield return null;
        }
    }
}
