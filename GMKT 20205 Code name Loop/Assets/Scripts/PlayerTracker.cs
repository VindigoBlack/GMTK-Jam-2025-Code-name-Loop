using UnityEngine;

public class PlayerTracker : MonoBehaviour
{
    [SerializeField]
    private float speedDivider = 10f;

    public GameObject player;

    private float xSpeed;
    private float ySpeed;
    private Vector2 moveDirection;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        xSpeed = Mathf.Abs(((transform.position.x - player.transform.position.x) / speedDivider) * Time.deltaTime);
        ySpeed = Mathf.Abs(((transform.position.y - player.transform.position.y) / speedDivider) * Time.deltaTime);
        moveDirection = new Vector2(transform.position.x > player.transform.position.x ? -1f : 1f, transform.position.y > player.transform.position .y ? -1f : 1f);

        if (Mathf.Abs(transform.position.x - player.transform.position.x) > 0.1f || Mathf.Abs(transform.position.y - player.transform.position.y) > 0.1f)
        {
            transform.position = new Vector3(transform.position.x + (xSpeed * moveDirection.x), transform.position.y + (ySpeed * moveDirection.y), -10);
        }
    }
}
