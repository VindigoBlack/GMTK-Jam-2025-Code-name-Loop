using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float maxMoveSpeed;
    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private float maxJumpForce;
    [SerializeField]
    private Rigidbody2D myRigidbody;
    [SerializeField]
    private InputActionReference move;
    [SerializeField]
    private InputActionReference jump;

    private Vector2 _moveDirection;
    private Vector2 _jumpVelocity;

    void Start()
    {
        
    }

    void Update()
    {
        _moveDirection = move.action.ReadValue<Vector2>();
        _jumpVelocity = jump.action.ReadValue<Vector2>();
    }
    private void FixedUpdate()
    {
        Vector2 velocity = myRigidbody.linearVelocity;

        velocity.x += _moveDirection.x * moveSpeed;
        velocity.y += _jumpVelocity.y * jumpForce;

        velocity.x = Mathf.Clamp(velocity.x, -maxMoveSpeed, maxMoveSpeed);
        velocity.y = Mathf.Clamp(velocity.y, -Mathf.Infinity, maxJumpForce);

        myRigidbody.linearVelocity = velocity;
    }
}
