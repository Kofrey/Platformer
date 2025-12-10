using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    [SerializeField] public bool IsGround { get; private set; }

    private void OnTriggerStay2D(Collider2D collider)
    { 
        if (collider.gameObject.TryGetComponent<Ground>(out _))
            IsGround = true;
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.TryGetComponent<Ground>(out _))
            IsGround = false;
    }
}
