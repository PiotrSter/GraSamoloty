using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    Rigidbody2D rb;
    GameManager gm;
    GameObject player;

    void Awake()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
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
            Destroy(this.gameObject);
        }
        
        if (obj.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }

}
