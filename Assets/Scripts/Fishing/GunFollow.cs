using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFollow : MonoBehaviour
{
    [SerializeField]
    private Transform aimLine;
    private float attackAngle=45;
    void Start()
    {
        
    }
    void Update()
    {
        Vector3 targetLine = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        targetLine.z = 0;
        float angle =Vector3.SignedAngle(transform.up, targetLine,Vector3.forward);
        if (angle >= attackAngle)
        {
            angle = attackAngle;
        }
        else if (angle < -attackAngle)
        {
            angle = -attackAngle;
        }
        aimLine.eulerAngles = transform.eulerAngles + new Vector3(0, 0, angle);
    }
}
