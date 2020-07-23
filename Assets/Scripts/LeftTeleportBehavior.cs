using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftTeleportBehavior : MonoBehaviour
{
    public Transform playerTransform;
    public Transform enemyTransform;

    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.gameObject.tag == "Player")
        {
            playerTransform.position = new Vector3(72.5f - 5f, playerTransform.position.y, 0);
        }
        
        if (obj.gameObject.tag == "Enemy")
        {
            enemyTransform.position = new Vector3(72.5f - 5f, enemyTransform.position.y, 0);
        }
    }
    
}
