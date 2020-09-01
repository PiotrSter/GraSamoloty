using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public Transform playerTransform;
    private float cameraOffset = -10f;

    void Update()
    {
        transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, cameraOffset);
    }
}
