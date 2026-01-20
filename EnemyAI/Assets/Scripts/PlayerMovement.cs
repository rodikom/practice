using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public InputActionReference move;
    private Rigidbody _rb;
    private Vector3 _moveDirection;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _moveDirection = move.action.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
       _rb.linearVelocity = new Vector3(_moveDirection.x   * moveSpeed, _rb.linearVelocity.y, _moveDirection.y * moveSpeed);
    }
}
