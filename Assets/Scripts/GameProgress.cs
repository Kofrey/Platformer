using UnityEngine;
using UnityEngine.UI;

public class GameProgress : MonoBehaviour
{
    [SerializeField] private Slider _progressSlider;

    private int _progressAmount;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
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

    // Update is called once per frame
    void Update()
    {
        
    }
}