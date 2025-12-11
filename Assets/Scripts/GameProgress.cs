using UnityEngine;
using UnityEngine.UI;

public class GameProgress : MonoBehaviour
{
    [SerializeField] private Slider _progressSlider;

    private int _progressAmount;
    
    private void Start()
    {
        _progressAmount = 0;
        _progressSlider.value = 0;
        Coin.OnCoinCollect += IncreaseProgressAmount;
    }

    private void IncreaseProgressAmount(int amount)
    {
        _progressAmount += amount;
        _progressSlider.value = _progressAmount;
    }
}
