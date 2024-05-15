using UnityEngine;

public class PlayerGroundCheck : MonoBehaviour
{
    [SerializeField] private float checkRadius = 0.1f;
    [SerializeField] private LayerMask groundLayer;
    private Collider[] colliders = new Collider[1];

    public bool IsGrounded => Physics.OverlapSphereNonAlloc(transform.position, checkRadius, colliders, groundLayer) != 0;

#if UNITY_EDITOR

    private void OnDrawGizmos()
    {
        Gizmos.color = Physics.OverlapSphereNonAlloc(transform.position, checkRadius, colliders, groundLayer) != 0 ? Color.green : Color.red;
        Gizmos.DrawWireSphere(transform.position, checkRadius);
    }

#endif
}