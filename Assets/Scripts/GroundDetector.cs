using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    [SerializeField] private bool _drawCubeGizmo = true;
    [SerializeField] private Vector2 _detectorSize;

    public bool IsGround()
    {
        Collider2D[] hits = Physics2D.OverlapBoxAll(transform.position, _detectorSize, 0);
        
        foreach (Collider2D collider in hits)
        {
            if(collider.gameObject.TryGetComponent<Ground>(out _))
                return true;
        }

        return false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        
        if (_drawCubeGizmo)
            Gizmos.DrawWireCube(transform.position,  new Vector3(_detectorSize.x, _detectorSize.y, transform.localScale.z));
    }
}
