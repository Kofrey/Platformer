using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AbilityActivator : MonoBehaviour
{
    [SerializeField] private VampireAbility _ability;
    [SerializeField] private bool _isReady = true;
    [SerializeField] private float _executionTime = 6f;
    [SerializeField] private float _cooldown = 4f;

    public void Activate()
    {
        if(_isReady)
        {
            _ability.gameObject.SetActive(true);
            _isReady = false;
            StartCoroutine(ExecuteCount());
        }
    }

    public void Deactivate()
    {
        _ability.gameObject.SetActive(false);
    }

    private IEnumerator ExecuteCount()
    {
        yield return new WaitForSeconds(_executionTime);
        Deactivate();
        yield return new WaitForSeconds(_cooldown);
        _isReady = true;
    }
}
