using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public bool isGrounded;
    public bool isJumping;
    public float coyoteTimeCounter;

    [Space(15)]
    public float moveSpeed;
    public float jumpForce;
    public bool canDoubleJump;
    public float gravity;
    public float coyoteTime;
    public float fallMultiplier;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Physics.gravity = new Vector3(0.0f, gravity, 0.0f);
    }

    void Update()
    {
        Move();
        Jump();

        if (!isGrounded && rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
    }

    private void Move()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        if (moveInput > 0)
        {
            this.transform.localScale = new Vector3(1, 1, 1);
        }
        else if (moveInput < 0)
        {
            this.transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    private void Jump()
    {
        if (isGrounded)
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space) && (isGrounded || coyoteTimeCounter > 0.0f || (canDoubleJump && !isJumping)))
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce);
            isJumping = !isGrounded;
            isGrounded = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
            isJumping = false;
        }
    }
}
