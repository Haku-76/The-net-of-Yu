using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    [SerializeField]
    private float Speed;
    private void FixedUpdate()
    {
        transform.Translate(transform.up*Speed*Time.fixedDeltaTime,Space.World);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("budaoyule");
    }
}
