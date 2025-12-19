using UnityEngine;
using UnityEngine.UI;

public class HealthUpdater : MonoBehaviour
{
    [SerializeField] protected Health _health;
    [SerializeField] protected Slider _slider;

    private void OnEnable()
    { 
        int max = _health.Max;
        SetMaxValues(max);
        SetValues(max);
        _health.AmountChanged += SetValues;
    }

    private void OnDisable()
    {
        _health.AmountChanged -= SetValues;
    }

    protected virtual void SetMaxValues(int value)
    {
        _slider.maxValue = value;
    }

    protected virtual void SetValues(int health)
    {
        _slider.value = health;
    }
}