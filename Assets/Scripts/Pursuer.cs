using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Pursuer : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed = 2f;
    [SerializeField] private float _smoothness = 0.2f;
    [SerializeField] private float _minDistance = 2f; 
    
    private Rigidbody _rigidbody;
    private Vector3 _direction;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _direction = _target.position - transform.position;
        float distanceToPlayer = _direction.magnitude;

        if (distanceToPlayer > _minDistance)
        {
            _direction.Normalize();
            _rigidbody.velocity = Vector3.Lerp(_rigidbody.velocity, _direction * _speed, _smoothness);
        }
        else
        {
                _rigidbody.velocity = Vector3.zero;
        }   
    }
}