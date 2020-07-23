using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpTeleportBehavior : MonoBehaviour
{
    public Transform playerTransform;
    public Transform enemyTransform;

    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.gameObject.tag == "Player")
        {
            playerTransform.position = new Vector3(playerTransform.position.x, -46.6f + 5f, 0);
        }

        if (obj.gameObject.tag == "Enemy")
        {
            enemyTransform.position = new Vector3(enemyTransform.position.x, -46.6f + 5f, 0);
        }
    }
}
