using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public Transform playerTransform;
    private float cameraOffset = -10f;

    void Update()
    {
        if (transform.position.x >= 39.8f)
        {
            transform.position = new Vector3(39.8f, playerTransform.position.y, cameraOffset);
            if (transform.position.y >= 29.5f)
            {
                transform.position = new Vector3(playerTransform.position.x, 29.5f, cameraOffset);
            }
            else if (transform.position.y <= -29.5f)
            {
                transform.position = new Vector3(playerTransform.position.x, -29.5f, cameraOffset);
            }
            else if (playerTransform.position.x < 39.7f)
            {
                transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, cameraOffset);
            }
        }
        else if (transform.position.x <= -39.8f)
        {
            transform.position = new Vector3(-39.8f, playerTransform.position.y, cameraOffset);
            if (transform.position.y >= 29.5f)
            {
                transform.position = new Vector3(playerTransform.position.x, 29.5f, cameraOffset);
            }
            else if (transform.position.y <= -29.5f)
            {
                transform.position = new Vector3(playerTransform.position.x, -29.5f, cameraOffset);
            }
            else if (playerTransform.position.x > -39.7f)
            {
                transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, cameraOffset);
            }
        }
        else if (transform.position.y >= 29.5f)
        {
            transform.position = new Vector3(playerTransform.position.x, 29.5f, cameraOffset);
            if (transform.position.x >= 39.8f)
            {
                transform.position = new Vector3(39.8f, playerTransform.position.y, cameraOffset);
            }
            else if (transform.position.x <= -39.8f)
            {
                transform.position = new Vector3(-39.8f, playerTransform.position.y, cameraOffset);
            }
            else if (playerTransform.position.y < 29.4f)
            {
                transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, cameraOffset);
            }
        }
        else if (transform.position.y <= -29.5f)
        {
            transform.position = new Vector3(playerTransform.position.x, -29.5f, cameraOffset);
            if (transform.position.x >= 39.8f)
            {
                transform.position = new Vector3(39.8f, playerTransform.position.y, cameraOffset);
            }
            else if (transform.position.x <= -39.8f)
            {
                transform.position = new Vector3(-39.8f, playerTransform.position.y, cameraOffset);
            }
            else if (playerTransform.position.y > -29.4f)
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
