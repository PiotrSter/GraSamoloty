using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    Rigidbody2D rb;
    public float planeSpeed = 20.0f;
    public float planeSpeedRotate = 1.0f;
    private Vector3 planePosition;

    private void Awake()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        planePosition = this.gameObject.transform.position;
    }

    void Update()
    {
        
        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity = transform.up * planeSpeed;
        }
        else
        {
            rb.velocity = Vector2.zero;
        }

        if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.Rotate(new Vector3(0, 0, planeSpeedRotate));
        }
        if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.Rotate(new Vector3(0, 0, -planeSpeedRotate));
        }

        /*
        if (Input.GetKey(KeyCode.W))
        {
            planePosition.y +=  planeSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            this.gameObject.transform.Rotate(new Vector3(0, 0, planeSpeedRotate));
            //planePosition.x += -planeSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.gameObject.transform.Rotate(new Vector3(0, 0, -planeSpeedRotate));
            //planePosition.x += planeSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            planePosition.y += -planeSpeed * Time.deltaTime;
        }
        */
        //this.gameObject.transform.position = planePosition;
        //planePosition.x = Mathf.Clamp(planePosition.x, -29.1f, 30f); 
        //planePosition.x += Input.GetAxis("Horizontal") * planeSpeed * Time.deltaTime;
        //planePosition.y += Input.GetAxis("Vertical") * planeSpeed * Time.deltaTime;
        //planePosition.y = Mathf.Clamp(planePosition.y, -18.8f, 12.7f);
        //this.gameObject.transform.position = planePosition;


    }
}
