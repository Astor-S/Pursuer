using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;
    private Transform _transform;
    private CharacterController _characterController;

    private void Awake()
    {
        _transform = transform;
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (_characterController != null)
        {
            Vector3 playerSpeed = new Vector3(Input.GetAxis("Horizontal"),0, Input.GetAxis("Vertical"));
            playerSpeed *= Time.deltaTime * _speed;

            if(_characterController.isGrounded)
                _characterController.Move(playerSpeed + Vector3.down);
            else
                _characterController.Move(_characterController.velocity + Physics.gravity * Time.deltaTime);
        }
    }
}