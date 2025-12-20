using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

public class DisplayActionTimeAndCooldown : MonoBehaviour
{
    [SerializeField] private Slider _actionSlider;
    [SerializeField] private Slider _cooldownSlider;
    [SerializeField] private AbilityActivator _activator;

    private void OnEnable()
    {
        float actionTime = _activator.ActionTime;
        float cooldownTime = _activator.Cooldown;
        _actionSlider.value = 1;
        _cooldownSlider.value = 0;
        StartCoroutine(OperateBar(actionTime, cooldownTime));
    }

    private IEnumerator OperateBar(float actionTime, float cooldownTime)
    {
        while(_actionSlider.value != 0)
        {
            _actionSlider.value -= Time.deltaTime / actionTime;
            yield return null;
        }  
        
        while(_cooldownSlider.value < 1)
        {
            _cooldownSlider.value += Time.deltaTime / cooldownTime;
            yield return null;
        }
    }
}
