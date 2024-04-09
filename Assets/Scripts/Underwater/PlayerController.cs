using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float gravityScale;
    public float verticalSpeed;
    public float horizontalSpeed;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Physics.gravity = new Vector3(0, -9.81f * gravityScale, 0);
    }

    void Update()
    {

        float h = Input.GetAxis("Horizontal") * horizontalSpeed;
        float v = Input.GetAxis("Vertical") * verticalSpeed;

        if (h > 0)
        {
            this.transform.localScale = new Vector3(1, 1, 1);
        }
        else if (h < 0)
        {
            this.transform.localScale = new Vector3(-1, 1, 1);
        }

        rb.velocity = new Vector3(h, v, 0);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {

        }
    }
}
