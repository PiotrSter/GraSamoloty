using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotBullet : MonoBehaviour
{
    public GameObject Bullet;
    public float bulletDelay = 0.5f;
    public float shotDelay;

    void Update()
    {
        shotDelay -= Time.deltaTime;
        if (shotDelay <= 0)
        {
            if (Input.GetButtonDown("Fire2"))
            {
                shotBullet();
                shotDelay = bulletDelay;
            }
        }
    }

    void shotBullet()
    {
        Instantiate(Bullet, transform.position, transform.rotation);
    }

}
