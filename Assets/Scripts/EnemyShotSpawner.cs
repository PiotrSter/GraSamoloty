using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShotSpawner : MonoBehaviour
{
    public GameObject Bullet;
    private GameObject Player;
    private GameObject Enemy;
    public float bulletDelay = 2f;
    public float shotDelay;
    //LayerMask PlayerLayer;

    private void Awake()
    {
        this.Player = GameObject.Find("Player");
        this.Enemy = GameObject.Find("StandardEnemy");

    }
    /*
    void Start()
    {
        PlayerLayer = LayerMask.NameToLayer("Player");
    }
    */
    void FixedUpdate()
    {
        int layerMask = 1 << 8;
        //float range = 50f;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, Mathf.Infinity, layerMask);
        //Ray ray = new Ray(transform.position, Vector2.up);
        //RaycastHit hitInfo;
        float distance = Vector2.Distance(Enemy.transform.position, Player.transform.position);        
        if (hit.collider != null)
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
        Instantiate(Bullet, transform.position, transform.rotation);
    }
}
