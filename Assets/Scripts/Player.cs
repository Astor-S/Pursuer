using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;
    private Transform _transform;
    private CharacterController _characterController;
    
    private string _horizontalAxis = "Horizontal";
    private string _verticalAxis = "Vertical";

    private void Awake()
    {
        _transform = transform;
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Vector3 playerSpeed = new Vector3(Input.GetAxis(_horizontalAxis),0, Input.GetAxis(_verticalAxis));
        playerSpeed *= Time.deltaTime * _speed;
        _characterController.Move(playerSpeed + Physics.gravity * Time.deltaTime);
    }
}