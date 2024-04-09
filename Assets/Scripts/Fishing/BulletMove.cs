using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    [SerializeField]
    private float Speed;
    
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        transform.Translate(transform.up*Speed*Time.fixedDeltaTime,Space.World);
    }
}
