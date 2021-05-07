using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform player;

    [SerializeField]
    private Vector3 cameraOffset;

    [SerializeField]
    private Vector3 cameraRotation;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
        Camera.main.transform.rotation = Quaternion.Euler(cameraRotation);
    }

    // Always do camera follow code last, after player has moved.
    void LateUpdate()
    {
        Camera.main.transform.position = player.transform.position + cameraOffset;
    }
}
