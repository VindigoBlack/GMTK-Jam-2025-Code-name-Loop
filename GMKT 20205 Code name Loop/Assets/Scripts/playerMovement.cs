using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
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
    private float dashTimeInSeconds = 1f;
    [SerializeField]
    private float dashMultiplier;
    [SerializeField]
    private bool isFalling;
    [SerializeField]
    private bool hasDashed;
    [SerializeField]
    private Rigidbody2D myRigidbody;

    public bool isFacingLeft;
    public GroundDetection groundDetector;
    public InputActionReference move;
    public InputActionReference jump;
    public InputActionReference dash;
    

    private Vector2 _moveDirection;
    private Vector2 _jumpVelocity;

    private float currentDashTime;

    void Start()
    {
        currentDashTime = dashTimeInSeconds;
        isFacingLeft = false;
    }

    void Update()
    {
        _moveDirection = move.action.ReadValue<Vector2>();
        _jumpVelocity = jump.action.ReadValue<Vector2>();

        if (dash.ToInputAction().WasPressedThisFrame() && !hasDashed && !groundDetector.isGrounded)
        {
            hasDashed = true;
        }

        if (groundDetector.isGrounded) 
        {
            hasDashed = false;
            currentDashTime = dashTimeInSeconds;
        }

        if (_moveDirection.x < 0)
        {
            isFacingLeft = true;
        }
        else if (_moveDirection.x > 0)
        {
            isFacingLeft = false;
        }
    }
    private void FixedUpdate()
    {
        Vector2 velocity = myRigidbody.linearVelocity;

        isFalling = (myRigidbody.linearVelocity.y < -.1f && !groundDetector.isGrounded);

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

        if (hasDashed && currentDashTime > 0 && !groundDetector.isGrounded)
        {
            currentDashTime -= Time.deltaTime;
            velocity.x *= dashMultiplier;
            myRigidbody.linearVelocity = velocity;
        }
     
    }
    

}
