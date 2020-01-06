using UnityEngine;

public class camcontroll : MonoBehaviour
{
    public float camspeed = 10;

    private Transform target;

    private void Start()
    {
        target = GameObject.Find("play").transform;
    }

    private void LateUpdate()
    {
        Vector3 cam = transform.position;
        Vector3 tar = target.position;
        tar.z = -10;
        tar.y = Mathf.Clamp(tar.y, -0.2f, 1);
        transform.position = Vector3.Lerp(cam, tar, 0.3f * Time.deltaTime * camspeed);
    }
}
