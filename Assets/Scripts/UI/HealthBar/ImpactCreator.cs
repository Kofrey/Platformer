using UnityEngine;
using UnityEngine.UI;

public class ImpactCreator : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] protected int _impact = 1;
    [SerializeField] protected Health[] _healths;

    private void OnEnable()
    {
        _button.onClick.AddListener(Execute);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(Execute);
    }

    public virtual void Execute()
    {
        foreach (Health health in _healths)
        {
            if(health != null)
                health.TakeDamage(_impact);
        }
    }
}
