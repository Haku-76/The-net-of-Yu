using UnityEngine;

public class TargetChaser: MonoBehaviour
{
    public Transform target;

    void Update()
    {
        this.transform.position = new Vector2(target.position.x, target.position.y);
    }
}
