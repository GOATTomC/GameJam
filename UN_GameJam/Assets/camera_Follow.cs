
using UnityEngine;

public class camera_Follow : MonoBehaviour {
    public Transform target;

    public float smoothFactor = 0.125f;
    public Vector3 offset;

    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothFactor * Time.deltaTime);
        transform.position = smoothedPosition;

    }
}

