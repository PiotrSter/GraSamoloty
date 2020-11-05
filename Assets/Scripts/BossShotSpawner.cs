using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShotSpawner : MonoBehaviour
{
    public GameObject BulletEnemy;
    public float bulletDelay = 2f;
    public float shotDelay;
    public bool canShoot = false;
    private GameObject player;

    void Awake()
    {
        this.player = GameObject.Find("Player");
    }

    void FixedUpdate()
    {
        if (canShoot == true)
        {
            shotDelay -= Time.deltaTime;
            if (shotDelay <= 0)
            {
                shotBullet();
                shotDelay = bulletDelay;
            }

        }

    }

    void shotBullet()
    {
        Instantiate(BulletEnemy, this.transform.position, transform.rotation);
    }
}
