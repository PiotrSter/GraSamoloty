using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudBehavior : MonoBehaviour
{
    GameManager gm;
    Rigidbody2D rb;

    void Awake()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        rb = this.gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        this.rb.velocity = transform.right * gm.cloudSpeed;  
    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        if(obj.gameObject.tag == "Destroyer")
        {
            Destroy(this.gameObject);
        }
    }
}
