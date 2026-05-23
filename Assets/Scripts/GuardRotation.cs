using UnityEngine;

public class GuardRotation : MonoBehaviour
{
    [SerializeField] private float _rotateInterval = 5f;
    [SerializeField] private float _rotationAngle = 90f;

    private float _timer;

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _rotateInterval)
        {
            RotateGuard();
            _timer = 0f;
        }
    }

    private void RotateGuard()
    {
        transform.Rotate(0f, 0f, _rotationAngle);
    }
}
