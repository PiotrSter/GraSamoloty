using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownTeleportBehavior : MonoBehaviour
{
    public Transform playerTransform;

    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.gameObject.tag == "Player")
        {
            playerTransform.position = new Vector3(playerTransform.position.x, 46.6f - 5f, 0);
        }
    }
}
