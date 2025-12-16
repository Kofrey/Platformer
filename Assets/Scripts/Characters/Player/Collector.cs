using UnityEngine;

public class Collector : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private GameProgress _gameProgress;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.TryGetComponent<ObjectSpawned>(out ObjectSpawned resource))
        {
            if (resource is Coin)
            {
                OnCoinCollecting((resource as Coin).Worth);
                resource.Collect();
            }
            else if (resource is HealItem)
            {
                OnHealCollecting((resource as HealItem).Amount);     
                resource.Collect();       
            }
        }
    }

    private void OnHealCollecting(int amount)
    {
        _health.Heal(amount);
    }

    private void OnCoinCollecting(int worth)
    {
        _gameProgress.IncreaseProgressAmount(worth);
    }
}
