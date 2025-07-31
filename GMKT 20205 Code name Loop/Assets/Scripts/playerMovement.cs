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
    private float groundFriction; // 0 = Complete Stop 1 = No Friction
    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private float maxJumpForce;
    [SerializeField]
    private float downwardsVelocityForce;
    [SerializeField]
    private bool isFalling;
    [SerializeField]
    private Rigidbody2D myRigidbody;

    public GroundDetection groundDetector;
    public InputActionReference move;
    public InputActionReference jump;

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
        isFalling = (myRigidbody.linearVelocity.y < -.1f && !groundDetector.isGrounded);

        Vector2 velocity = myRigidbody.linearVelocity;

        velocity.x += _moveDirection.x * moveSpeed;
        velocity.y += groundDetector.isGrounded ? _jumpVelocity.y * jumpForce : 0;

        velocity.x = Mathf.Clamp(velocity.x, -maxMoveSpeed, maxMoveSpeed);
        velocity.y = Mathf.Clamp(velocity.y, -Mathf.Infinity, maxJumpForce);

        if (groundDetector.isGrounded)
        {
            velocity.x *= groundFriction;
        }

        if (isFalling)
        {
            velocity.y -= downwardsVelocityForce;
        }

        myRigidbody.linearVelocity = velocity;
    }
}
