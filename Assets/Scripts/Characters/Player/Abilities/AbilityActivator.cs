using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AbilityActivator : MonoBehaviour
{
    [SerializeField] private VampireAbility _ability;
    [SerializeField] private GameObject _UIObject;
    [SerializeField] private bool _isReady = true;
    [SerializeField] private float _actionTime = 6f;
    [SerializeField] private float _cooldown = 4f;

    public float ActionTime => _actionTime;
    public float Cooldown => _cooldown;

    public void Activate()
    {
        if(_isReady)
        {
            _ability.gameObject.SetActive(true);
            _UIObject.SetActive(true);
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
        yield return new WaitForSeconds(_actionTime);
        Deactivate();
        yield return new WaitForSeconds(_cooldown);
        _UIObject.SetActive(false);
        _isReady = true;
    }
}
