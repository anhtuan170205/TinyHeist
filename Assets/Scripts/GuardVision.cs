using UnityEngine;

public class GuardVision : MonoBehaviour
{
    [SerializeField] private Transform _guardEye;
    [SerializeField] private LayerMask _obstacleLayer;
    [SerializeField] private LayerMask _playerLayer;
    

    private void OnTriggerStay2D(Collider2D other) 
    {
        if ((1 << other.gameObject.layer & _playerLayer) == 0) return;

        Vector2 directionToPlayer = (other.transform.position - _guardEye.position).normalized;
        float distanceToPlayer = Vector2.Distance(_guardEye.position, other.transform.position);

        RaycastHit2D hit = Physics2D.Raycast(_guardEye.position, directionToPlayer, distanceToPlayer, _obstacleLayer);

        if (hit.collider == null)
        {
            GameManager.Instance.Lose();
        }
    }
}
