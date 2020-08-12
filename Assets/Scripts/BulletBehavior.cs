using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    Rigidbody2D rb;
    GameManager gm;
    GameObject player;
    GameObject enemy;
    StandardEnemyBehavior enemySC;

    void Awake()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        enemy = GameObject.Find("StandardEnemy");
        enemySC = GetComponent<StandardEnemyBehavior>();
    }

    void Update()
    {
        this.rb.velocity = transform.up * gm.bulletSpeed;
    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        if(obj.gameObject.tag == "Destroyer")
        {
            Destroy(this.gameObject);
        }
        
        if (obj.gameObject.tag == "Enemy")
        {
            enemySC.enemyHp -= gm.playerDemage;
            Destroy(this.gameObject);
            if(enemySC.enemyHp <= 0)
            {
                Destroy(enemy);
            }
        }
        
        if (obj.gameObject.tag == "Player")
        {
            gm.playerHp -= gm.standardEnemyDemage;
            Destroy(this.gameObject);
            if(gm.playerHp <= 0)
            {
                Destroy(player);
                Time.timeScale = 0;
            }
        }
    }

}
