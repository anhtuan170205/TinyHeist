using UnityEngine;

public class GuardVision : MonoBehaviour
{
    [SerializeField] private Transform _guardEye;
    [SerializeField] private LayerMask _obstacleLayer;
    [SerializeField] private LayerMask _playerLayer;

    private Transform _target;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!IsInLayerMask(other.gameObject, _playerLayer))
        {
            return;
        }

        _target = other.transform;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform == _target)
        {
            _target = null;
        }
    }

    private void Update()
    {
        if (_target == null)
        {
            return;
        }

        CheckLineOfSight();
    }

    private void CheckLineOfSight()
    {
        Vector2 eyePosition = _guardEye.position;
        Vector2 targetPosition = _target.position;

        Vector2 directionToPlayer = (targetPosition - eyePosition).normalized;
        float distanceToPlayer = Vector2.Distance(eyePosition, targetPosition);

        RaycastHit2D hit = Physics2D.Raycast(eyePosition, directionToPlayer, distanceToPlayer, _obstacleLayer);

        Debug.DrawRay(eyePosition, directionToPlayer * distanceToPlayer, hit.collider == null ? Color.red : Color.yellow);

        if (hit.collider == null)
        {
            GameManager.Instance.Lose();
        }
    }

    private bool IsInLayerMask(GameObject obj, LayerMask layerMask)
    {
        return (layerMask.value & (1 << obj.layer)) != 0;
    }
}