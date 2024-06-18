
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float smoothSpeed = 0.125f;

  private void FixedUpdate() {
        Vector2 desirePosition = (Vector2)target.position;
        Vector2 smoothedPosition = Vector3.Lerp((Vector2)transform.position, desirePosition, smoothSpeed);

        transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, -10);
    }

}
