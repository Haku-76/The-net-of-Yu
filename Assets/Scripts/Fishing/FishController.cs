using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishController : MonoBehaviour
{
    public Item fishData;
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
    private bool isScared = false;
    [SerializeField]
    private float capturePossibility;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        RandomTarget();
    }
    void Update()
    {
        timer += Time.deltaTime;
        rb.velocity = transform.up * speed;
        if (timer > maxTime)
        {
            if (isScared)
            {
                if ((transform.position - BoatController.Instance.transform.position).magnitude > 3)
                {
                    isScared = false;
                    RandomTarget();
                    timer = 0;
                }
                else
                {
                    FishScared(BoatController.Instance.transform.position);
                }
            }
            else
            {
                RandomTarget();
                timer = 0;
            }
        }
    }
    private void RandomTarget()
    {
        Timer = Random.Range(minTime, maxTime);
        speed = Random.Range(minSpeed, maxSpeed);
        float rotateSp = Random.Range(minRotate, maxRotate);
        if (rotateSp > 20 || rotateSp < -20)
        {
            rotateSp = 0;
        }
        rb.angularVelocity = rotateSp;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "FishArea")
        {
            if (gameObject.activeInHierarchy)
            {
                transform.eulerAngles += new Vector3(0, 0, 180);
                rb.angularVelocity = -rb.angularVelocity;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (!isScared)
            {
                FishScared(BoatController.Instance.transform.position);
            }
        }
        else if (collision.tag=="FishWeb")
        {
            Debug.Log(capturePossibility >= Random.Range(0, 1f));
            if (capturePossibility>=Random.Range(0,1f))
            {
                CurrentSceneInventoryManager.Instance.AddItem("��", fishData.itemName, 1);
                Destroy(this.gameObject);
            }
            else
            {
                if (!isScared)
                {
                    FishScared(collision.transform.position);
                }
            }
        }
    }
    private void FishScared(Vector3 target)
    {
        isScared = true;
        timer = 0;
        Timer = 3;
        rb.angularVelocity = 0;
        speed = 7;
        transform.eulerAngles = new Vector3(0, 0, Vector3.SignedAngle(Vector3.up, transform.position-target, Vector3.forward));
    }
}
