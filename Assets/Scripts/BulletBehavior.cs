using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    Rigidbody2D rb;
    GameManager gm;
    GameObject player;
    //public GameObject enemy;

    void Awake()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        //StandardEnemyBehavior enemySc = enemy.GetComponent<StandardEnemyBehavior>();
        //enemy = GameObject.Find("StandardEnemy");
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
            //enemySc.enemyHp -= gm.playerDemage;
            Destroy(this.gameObject);
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
