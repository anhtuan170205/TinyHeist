using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    private Rigidbody2D _rb2D;
    private Vector2 _movement;

    private void Awake()
    {
        _rb2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _movement.x = Keyboard.current.aKey.isPressed ? -1 : (Keyboard.current.dKey.isPressed ? 1 : 0);
        _movement.y = Keyboard.current.wKey.isPressed ? 1 : (Keyboard.current.sKey.isPressed ? -1 : 0);
        _movement.Normalize();  
    }

    private void FixedUpdate()
    {
        _rb2D.MovePosition(_rb2D.position + _movement * _moveSpeed * Time.fixedDeltaTime);
    }
}
