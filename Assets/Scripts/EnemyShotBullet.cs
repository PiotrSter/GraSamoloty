using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShotBullet : MonoBehaviour
{
    public GameObject Bullet;
    private GameObject Player;
    private GameObject Enemy;
    public float bulletDelay = 0.5f;
    public float shotDelay;

    private void Awake()
    {
        this.Player = GameObject.Find("Player");
        this.Enemy = GameObject.Find("StandardEnemy");
    }

    void Update()
    {
        float distance = Vector2.Distance(Enemy.transform.position, Player.transform.position);
        shotDelay -= Time.deltaTime;
        if (shotDelay <= 0)
        {
            if(distance <= 20)
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
