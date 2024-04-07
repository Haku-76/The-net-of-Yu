using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishAreaController : MonoBehaviour
{
    [SerializeField]
    private List<FishController> fishControllers;
    void Start()
    {
        fishControllers = new List<FishController>(gameObject.GetComponentsInChildren<FishController>());
    }
}
