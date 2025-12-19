using UnityEngine;
using System;
using TMPro;

public class HealthText : HealthUpdater
{
    [SerializeField] private TMP_Text _currentText;
    [SerializeField] private TMP_Text _maxText;

    protected override void SetMaxValues(int value)
    {
        _maxText.text = value.ToString();
    }

    protected override void SetValues(int health)
    {
        _currentText.text = health.ToString();
    }
}
