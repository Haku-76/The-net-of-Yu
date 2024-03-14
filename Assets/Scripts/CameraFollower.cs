using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed;
    public float distance;
    public Vector2 offset;

    void LateUpdate()
    {
        Vector2 desiredPosition = new Vector2(target.position.x + offset.x, target.position.y + offset.y);
        Vector2 smoothedPosition = Vector2.Lerp(transform.position, desiredPosition, smoothSpeed);
        this.transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, -distance);
    }
}
