using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    [SerializeField]
    private Item itemData;
    private bool findTarget;
    private void Update()
    {
        if (FishingController.Instance.isGameOver())
        {
            Destroy(gameObject);
        }
        if (findTarget)
        {
            if (Vector3.Distance(transform.position,BoatController.Instance.transform.position)<0.2f)
            {
                CurrentSceneInventoryManager.Instance.AddItem(itemData);
                Destroy(gameObject);
            }
            transform.position = Vector3.Lerp(transform.position,BoatController.Instance.transform.position,Time.deltaTime*7f);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Player")
        {
            findTarget = true;
        }
    }
}
