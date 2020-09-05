 using UnityEngine;

public class CameraFollow : MonoBehaviour{

    private Vector3 target;
    public Transform Player;
    public Camera cam;
    public float PanRadius = 5;

    public float smoothness = 0.125f;
    public Vector3 offset;

    private void Update()
    {
        if (Input.GetMouseButton(1))
        {
            Vector3 mouse = Input.mousePosition;
            target = cam.ScreenToWorldPoint(mouse) - offset;
            Debug.Log(mouse + " " + target);

            if (Vector2.Distance(target, Player.position) > PanRadius)
                target = (Vector2)Player.position + ((Vector2)target - (Vector2)Player.position).normalized * PanRadius - (Vector2)offset;
        }
        else
        {
            target = Player.position;
        }
    }

    void LateUpdate ()
    {
        transform.position = Vector3.MoveTowards(transform.position, target + offset, smoothness * Time.deltaTime);
    }

}
