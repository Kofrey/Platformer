using UnityEngine;

public class Collector : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private GameProgress _gameProgress;

    public void OnHealCollecting(int amount)
    {
        _health.Heal(amount);
    }

    public void OnCoinCollecting(int worth)
    {
        _gameProgress.IncreaseProgressAmount(worth);
    }
}
