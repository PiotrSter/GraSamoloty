using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    Rigidbody2D rb;
    public float planeSpeed = 10.0f;
    public float planeSpeedRotate = 1.0f;

    private void Awake()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {       
        if (Input.GetKey(KeyCode.W))
        {
            this.rb.velocity = transform.up * planeSpeed;
        }
        else
        {
            this.rb.velocity = Vector2.zero;
        }
        if (Input.GetKey(KeyCode.A))
        {
            this.gameObject.transform.Rotate(new Vector3(0, 0, planeSpeedRotate));
        }       
        if (Input.GetKey(KeyCode.D))
        {
            this.gameObject.transform.Rotate(new Vector3(0, 0, -planeSpeedRotate));
        }
    }
}
