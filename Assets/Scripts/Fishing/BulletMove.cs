using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    [SerializeField]
    private float Speed;
    [SerializeField]
    private GameObject fishWeb;
    [SerializeField]
    private float webLevel = 1;
    [SerializeField]
    private float webTime = 1;
    private void FixedUpdate()
    {
        transform.Translate(transform.up*Speed*Time.fixedDeltaTime,Space.World);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Fish")
        {
            Destroy(this.gameObject);
        }
    }
    private void OnDestroy()
    {
        GameObject temp = GameObject.Instantiate(fishWeb, transform.position, transform.rotation);
        temp.transform.localScale = Vector3.one * webLevel;
        Destroy(temp, webTime);
    }
}
