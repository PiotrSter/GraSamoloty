using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftTeleportBehavior : MonoBehaviour
{
    public Transform playerTransform;
    public PlayerControl player;

    void Awake()
    {
        player = GameObject.Find("Player").GetComponent<PlayerControl>();
    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        if (player.canTp % 2 != 0)
        {
            if (obj.gameObject.tag == "Player")
            {
                playerTransform.position = new Vector3(72.5f, playerTransform.position.y, 0);
                player.canTp = 1;
            }           
        }
        else
        {
            player.canTp = 0;
        }
    }
    
}
