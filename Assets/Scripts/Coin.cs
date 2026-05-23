using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Coin : MonoBehaviour
{
    [SerializeField] private int _value = 1;
    [SerializeField] private float _collectRadius = 0.5f;
    [SerializeField] private LayerMask _playerLayer;

    private void Update()
    {
        Collider2D player = Physics2D.OverlapCircle(transform.position, _collectRadius, _playerLayer);

        if (player == null)
        {
            return;
        }

        Collect();
    }

    private void Collect()
    {
        Debug.Log($"Player collected a coin worth {_value} points!");
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, _collectRadius);
    }
}