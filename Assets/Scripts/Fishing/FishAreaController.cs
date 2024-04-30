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
    [SerializeField]
    private Item polluteData;
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
        minShowDistanceY = minHeight-Camera.main.orthographicSize*1.1f-2.6f;
        maxShowDistanceY= maxHeight + Camera.main.orthographicSize * 1.1f;
        for(int i=0;i<fishControllers.Count;i++)
        {
            if (polluteData.itemHeld >= fishControllers[i].fishData.needPolluteValue)
            {
                if (fishControllers[i].fishData.pullteFish != null)
                {
                    GameObject go=GameObject.Instantiate(fishControllers[i].fishData.pullteFish, transform.GetChild(0));
                    go.transform.position = fishControllers[i].transform.position;
                    go.transform.eulerAngles = fishControllers[i].transform.eulerAngles;
                    Destroy(fishControllers[i].gameObject);
                    fishControllers[i] = go.GetComponent<FishController>();
                }
            }
            fishControllers[i].gameObject.GetComponentInChildren<SpriteRenderer>().sortingOrder = sorting;
            sorting++;
        }
    }
    private void Update()
    {
        if (FishingController.Instance.isGameOver())
        {
            ChangeFishState(false);
            return;
        }
        if (BoatController.Instance.transform.position.y>minShowDistanceY&&
            BoatController.Instance.transform.position.y<maxShowDistanceY)
        {
            ChangeFishState(true);
        }
        else
        {
            ChangeFishState(false);
        }
    }
    private void ChangeFishState(bool state)
    {
        for (int i=0;i<transform.childCount;i++)
        {
            if (transform.GetChild(i).gameObject.activeSelf != state)
            {
                transform.GetChild(i).gameObject.SetActive(state);
            }
        }
    }
}
