using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShotSpawner : MonoBehaviour
{
    public GameObject BulletEnemy;
    public float bulletDelay = 2f;
    public float shotDelay;
    public bool canShoot = false;
    
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
        Instantiate(BulletEnemy, this.transform.position, this.transform.rotation);
    }

}
