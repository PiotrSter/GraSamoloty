using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionShootArea : MonoBehaviour
{
    EnemyShotSpawner enemyShot;

    void Awake()
    {
        enemyShot = GameObject.Find("EnemyShotSpawn").GetComponent<EnemyShotSpawner>();        
    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.gameObject.tag == "Player")
        {
            enemyShot.canShoot = true;
        }
    }

    void OnTriggerExit2D(Collider2D obj)
    {
        if (obj.gameObject.tag == "Player")
        {
            enemyShot.canShoot = false;
        }
    }
}
