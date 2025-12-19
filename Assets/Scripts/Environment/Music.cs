using UnityEngine;
using UnityEngine.UI;

public class Music : MonoBehaviour
{
    [SerializeField] private AudioClip _backgroundMusic;
    [SerializeField] private Slider _musicSlider;

    private AudioSource _audioSource;
    private bool _isPlaying = true;

    public bool IsPlaying => _isPlaying;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        if(_backgroundMusic != null)
        {
            PlayBackgroundMusic(false, _backgroundMusic);
        }

        _musicSlider.onValueChanged.AddListener(delegate { SetVolume(_musicSlider.value); });
    }

    public void SetVolume(float value)
    {
        _audioSource.volume = value;
    }

    public void PlayBackgroundMusic(bool isResetSong = true, AudioClip audioClip = null)
    {
        if(audioClip != null)
        {
            _audioSource.clip = audioClip;
        }
        
        if(_audioSource.clip != null)
        {
            if (isResetSong)
            {
                _audioSource.Stop();
            }

            _audioSource.Play();
            _isPlaying = true;
        }
    }

    public void PauseBackgroundMusic()
    {
        _audioSource.Pause();
        _isPlaying = false;
    }
}
