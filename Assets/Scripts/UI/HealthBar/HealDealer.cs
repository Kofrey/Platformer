using UnityEngine;
using UnityEngine.UI;

public class HealDealer : ImpactCreator
{
    public override void Execute()
    {
        foreach (Health health in _healths)
        {
            if(health != null)
                health.Heal(_impact);
        }
    }
}
