using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMoveMenu : MonoBehaviour
{
    Rigidbody2D rb;
    public float planeSpeed = 20.0f;

    void Awake()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        this.rb.velocity = transform.up * planeSpeed;
    }
}
