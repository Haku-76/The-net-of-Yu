using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatController : MonoBehaviour
{
    public static BoatController Instance { get; private set; }
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
    [SerializeField]
    private GameObject Bullet;
    [SerializeField]
    private float cdTime=1.5f;
    private float downTimer;
    [SerializeField]
    private float downTime = 3;
    private bool isCd;
    [SerializeField]
    private Animator boatAnm;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (FishingController.Instance.isGameOver())
        {
            return;
        }
        if (!isCollidering)
        {
            Attack();
        }
        else
        {
            ClearCharge();
            attackRange.SetActive(false);
        }
    }
    private void FixedUpdate()
    {
        if (FishingController.Instance.isGameOver())
        {
            rb.velocity = Vector3.zero;
            return;
        }
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
        boatAnm.SetFloat("moveSpeed", move.y);
        rb.velocity = transform.up*move.y*moveSpeed;
    }
    private void Attack()
    {
        if (Input.GetMouseButton(1))
        {
            attackRange.SetActive(true);
            if (!isCd) 
            {
                BulletCharge();
            }
        }
        else
        {
            ClearCharge();
            attackRange.SetActive(false);
        }
    }
    private void ClearCharge()
    {
        downTimer = 0;
    }
    private void BulletCharge()
    {
        if (Input.GetMouseButton(0))
        {
            downTimer += Time.deltaTime;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            GameObject temp = GameObject.Instantiate(Bullet, firePos.position, firePos.rotation);
            if (downTimer > downTime)
            {
                downTimer = 0.8f;
            }
            else if (downTimer < 0.5)
            {
                downTimer = 0.3f;
            }
            else
            {
                downTimer =0.3f+downTimer / downTime * 0.5f;
            }
            isCd = true;
            Invoke("TurnToReady", cdTime);
            Destroy(temp, downTimer);
            ClearCharge();
        }
    }
    private void TurnToReady()
    {
        isCd = false;
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
