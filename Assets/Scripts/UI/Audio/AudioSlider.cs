using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSlider : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _mixer;
    [SerializeField] private Slider _slider;
    [SerializeField] private string _mixerVolumeName;

    private float _minValue = -80f;

    private void OnEnable()
    {
        _slider.onValueChanged.AddListener(ChangeVolume);
    }

    private void OnDisable()
    {
        _slider.onValueChanged.RemoveListener(ChangeVolume);
    }

    private void Start() 
    {
        _slider.value = PlayerPrefs.GetFloat(_mixerVolumeName, 1);
    }

    public void ChangeVolume(float volume)
    {
        if(volume == 0)
            _mixer.audioMixer.SetFloat(_mixerVolumeName, _minValue); 
        else
            _mixer.audioMixer.SetFloat(_mixerVolumeName, Mathf.Log10(volume) * 20); 

        PlayerPrefs.SetFloat(_mixerVolumeName, volume);
    }
}
