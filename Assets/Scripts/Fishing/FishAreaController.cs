using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishAreaController : MonoBehaviour
{
    [SerializeField]
    private List<FishController> fishControllers;
    private float minShowDistanceY;
    private float maxShowDistanceY;
    private int sorting = 30;
    void Start()
    {
        fishControllers = new List<FishController>(transform.GetChild(0).GetComponentsInChildren<FishController>());
        float minHeight = transform.position.y;
        float maxHeight = transform.position.y;
        foreach (Vector2 t in GetComponent<PolygonCollider2D>().points)
        {
            if (t.y + transform.position.y < minHeight)
            {
                minHeight = t.y+transform.position.y;
            }
            else if (t.y + transform.position.y > maxHeight)
            {
                maxHeight=t.y+transform.position.y;
            }
        }
        minShowDistanceY = minHeight-Camera.main.orthographicSize*1.1f;
        maxShowDistanceY= maxHeight + Camera.main.orthographicSize * 1.1f;
        foreach (var t in fishControllers)
        {
            t.gameObject.GetComponentInChildren<SpriteRenderer>().sortingOrder = sorting;
            sorting++;
        }
    }
    private void Update()
    {
        if (BoatController.Instance.transform.position.y>minShowDistanceY&&
            BoatController.Instance.transform.position.y<maxShowDistanceY)
        {
            if (!transform.GetChild(0).gameObject.activeSelf)
            {
                transform.GetChild(0).gameObject.SetActive(true);
            }
        }
        else
        {
            if (transform.GetChild(0).gameObject.activeSelf)
            {
                transform.GetChild(0).gameObject.SetActive(false);
            }
        }
    }
}
