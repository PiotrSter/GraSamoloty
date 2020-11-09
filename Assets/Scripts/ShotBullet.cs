using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotBullet : MonoBehaviour
{
    public GameObject Bullet;
    public float bulletDelay = 0.5f;
    public float shotDelay;
    public bool canShoot = true;
    
    GameManager gm;

    void Awake()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        shotDelay -= Time.deltaTime;
        if (shotDelay <= 0)
        {
            if (Input.GetButtonDown("Fire2"))
            {
                if (canShoot == true)
                {
                    if (gm.pause == false)
                    {
                        shotBullet();
                        shotDelay = bulletDelay;
                    }
                }
            }
        }
    }

    void shotBullet()
    {
        Instantiate(Bullet, transform.position, transform.rotation);
    }

}
