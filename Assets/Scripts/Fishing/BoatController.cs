using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatController : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField]
    private float moveSpeed=5;
    [SerializeField]
    private float rotateSpeed=5;
    [SerializeField]
    private GameObject attackRange;
    [SerializeField]
    private Transform firePos;
    private bool isCollidering;
    [SerializeField]
    private CameraShake cameraShake;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (!isCollidering)
        {
            Attack();
        }
        else
        {
            attackRange.SetActive(false);
        }
    }
    private void FixedUpdate()
    {
        if (!isCollidering)
        {
            Move();
        }
    }
    private void Move()
    {
        Vector2 move =new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (move.y != 0)
        {
            if (move.y > 0)
            {
                rb.angularVelocity = -move.x * rotateSpeed;
            }
            else
            {
                rb.angularVelocity = move.x * rotateSpeed;
            }
        }
        else
        {
            rb.angularVelocity = 0;
        }
        rb.velocity = transform.up*move.y*moveSpeed;
    }
    private void Attack()
    {
        if (Input.GetMouseButton(1))
        {
            attackRange.SetActive(true);
            if (Input.GetMouseButtonDown(0))
            {

            }
        }
        else
        {
            attackRange.SetActive(false);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isCollidering=true;
        rb.velocity = Vector2.zero;
        rb.freezeRotation = true;
        cameraShake.CameraShaking();
        Invoke("ChangeColliderState",0.5f);
        rb.AddForce((transform.position - collision.transform.position).normalized*0.7f, ForceMode2D.Impulse);
    }
    private void ChangeColliderState()
    {
        isCollidering = false;
        rb.freezeRotation = false;
    }
}
