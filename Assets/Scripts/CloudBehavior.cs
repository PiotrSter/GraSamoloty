using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudBehavior : MonoBehaviour
{
    public float cloudSpeed = 5f;
    Rigidbody2D rb;

    void Awake()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        this.rb.velocity = transform.right * cloudSpeed;  
    }
}
