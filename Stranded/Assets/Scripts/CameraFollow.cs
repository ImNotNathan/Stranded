 using UnityEngine;

public class CameraFollow : MonoBehaviour{

    public Transform target;

    public float smoothness = 0.125f;
    public Vector3 offset;

    void LateUpdate ()
    {
        transform.position = target.position + offset;
    }

}
