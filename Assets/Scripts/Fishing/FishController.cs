using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishController : MonoBehaviour
{
    [SerializeField]
    private float maxSpeed;
    [SerializeField]    
    private float minSpeed;
    [SerializeField]
    private float maxRotate;
    [SerializeField]
    private float minRotate;
    [SerializeField]
    private float maxTime;
    [SerializeField]
    private float minTime;
    private float speed = 0;
    private float Timer = 0;
    private float timer = 0;
    private Rigidbody2D rb;
    private FishState state = FishState.Normal;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        switch (state)
        {
            case FishState.Normal:
                timer += Time.deltaTime;
                rb.velocity=transform.up*speed;
                if (timer > maxTime)
                {
                    RandomTarget();
                    timer = 0;
                }
                break;
            case FishState.Outarea: 
                break;
            case FishState.Scared: 
                break;
        }
    }
    private void RandomTarget()
    {
        Timer=Random.Range(minTime, maxTime);
        speed=Random.Range(minSpeed, maxSpeed);
        rb.angularVelocity=Random.Range(minRotate, maxRotate);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        transform.eulerAngles += new Vector3(0, 0, 180);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.eulerAngles += new Vector3(0, 0, 180);
    }
}
public enum FishState
{
    Normal,
    Outarea,
    Scared
}
