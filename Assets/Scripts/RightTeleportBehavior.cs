using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightTeleportBehavior : MonoBehaviour
{
    public Transform playerTransform;

    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.gameObject.tag == "Player")
        {
            playerTransform.position = new Vector3(-72.5f, playerTransform.position.y, 0);
        }
    }
}
