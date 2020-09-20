using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDetectionShootArea : MonoBehaviour
{
    BossShotSpawner bossShot;

    void Awake()
    {
        bossShot = GameObject.Find("BossShotSpawn").GetComponent<BossShotSpawner>();
    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.gameObject.tag == "Player")
        {
            bossShot.canShoot = true;
        }
    }

    void OnTriggerExit2D(Collider2D obj)
    {
        if (obj.gameObject.tag == "Player")
        {
            bossShot.canShoot = false;
        }
    }
}
