using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioToggler : MonoBehaviour
{
    [SerializeField] private Toggle _toggle;
    [SerializeField] private AudioListener _listener; 

    private string _voiceEnabledName = "VoiceEnabled";

    private void OnEnable()
    {
        _toggle.onValueChanged.AddListener(ToggleAudio);
    }

    private void OnDisable()
    {
        _toggle.onValueChanged.RemoveListener(ToggleAudio);
    }

    private void Start() 
    {
        _toggle.isOn = PlayerPrefs.GetInt(_voiceEnabledName, 1) == 1;
    }

    public void ToggleAudio(bool enabled)
    {
        if (enabled)
            _listener.enabled = true;
        else 
            _listener.enabled = false;

        PlayerPrefs.SetInt(_voiceEnabledName, enabled ? 1 : 0);
    }
}
