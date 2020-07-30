using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public Transform playerTransform;
    private float cameraOffset = -10f;

    void Update()
    {
        if (transform.position.x >= 48.7f)
        {
            transform.position = new Vector3(48.7f, playerTransform.position.y, cameraOffset);
            if (transform.position.y >= 34.4f)
            {
                transform.position = new Vector3(playerTransform.position.x, 34.4f, cameraOffset);
            }
            else if (transform.position.y <= -34.4f)
            {
                transform.position = new Vector3(playerTransform.position.x, -34.4f, cameraOffset);
            }
            else if (playerTransform.position.x < 48.6f)
            {
                transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, cameraOffset);
            }
        }
        else if (transform.position.x <= -48.7f)
        {
            transform.position = new Vector3(-48.7f, playerTransform.position.y, cameraOffset);
            if (transform.position.y >= 34.4f)
            {
                transform.position = new Vector3(playerTransform.position.x, 34.4f, cameraOffset);
            }
            else if (transform.position.y <= -34.4f)
            {
                transform.position = new Vector3(playerTransform.position.x, -34.4f, cameraOffset);
            }
            else if (playerTransform.position.x > -48.6f)
            {
                transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, cameraOffset);
            }
        }
        else if (transform.position.y >= 34.4f)
        {
            transform.position = new Vector3(playerTransform.position.x, 34.4f, cameraOffset);
            if (transform.position.x >= 48.7f)
            {
                transform.position = new Vector3(48.7f, playerTransform.position.y, cameraOffset);
            }
            else if (transform.position.x <= -48.7f)
            {
                transform.position = new Vector3(-48.7f, playerTransform.position.y, cameraOffset);
            }
            else if (playerTransform.position.y < 34.3f)
            {
                transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, cameraOffset);
            }
        }
        else if (transform.position.y <= -34.4f)
        {
            transform.position = new Vector3(playerTransform.position.x, -34.4f, cameraOffset);
            if (transform.position.x >= 48.7f)
            {
                transform.position = new Vector3(48.7f, playerTransform.position.y, cameraOffset);
            }
            else if (transform.position.x <= -48.7f)
            {
                transform.position = new Vector3(-48.7f, playerTransform.position.y, cameraOffset);
            }
            else if (playerTransform.position.y > -34.3f)
            {
                transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, cameraOffset);
            }
        }
        else
        {
            transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, cameraOffset);
        }
    }
}
