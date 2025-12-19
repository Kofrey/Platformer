using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioPlayer : MonoBehaviour
{ 
    [SerializeField] private Button _button;
    [SerializeField] private AudioClip _audioClip;
    [SerializeField] private AudioSource _audioSource;

    private void OnEnable()
    {
        _button.onClick.AddListener(Play);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(Play);
    }

    private void Play()
    {
        _audioSource.PlayOneShot(_audioClip);
    }
}
