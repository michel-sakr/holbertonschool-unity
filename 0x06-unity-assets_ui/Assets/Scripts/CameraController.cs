using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset;
    private float turnSpeed = 3f;
    void Start()
    {
        offset = new Vector3(0f, 1.5f, -7f);
    }

    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
        if (Input.GetMouseButton(1))
        {
            offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * offset;
            offset = Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * -turnSpeed, Vector3.right) * offset;
            transform.position = player.transform.position + offset;
            transform.LookAt(player.transform.position);
        }
    }
}
