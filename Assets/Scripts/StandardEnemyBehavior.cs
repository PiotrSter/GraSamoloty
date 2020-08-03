using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardEnemyBehavior : MonoBehaviour
{
    /*
    private GameObject player;
    private Rigidbody2D rb;
    GameManager gm;
    public float maxDetectionRange = 50.0f;
    //public float minDetectionRange = 20.0f;

    //private bool back = false;

    private void Awake()
    {
        this.player = GameObject.Find("Player");
        this.rb = this.gameObject.GetComponent<Rigidbody2D>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Start()
    {
        this.transform.rotation = LookAtPlayer();

        this.rb.AddForce(this.gameObject.transform.up * gm.standardEnemySpeed, ForceMode2D.Impulse);
    }

    private void FixedUpdate()
    {
        float distance = Vector2.Distance(this.gameObject.transform.position, player.transform.position);

        if (distance <= maxDetectionRange && distance >= gm.distanceFromThePlayer)
            InDetectionArea();
        else if (distance < gm.distanceFromThePlayer)
            NearPlayer();
        else if (distance > maxDetectionRange)
            OutDetectionArea();

    }

    private void InDetectionArea()
    {
        this.transform.rotation = LookAtPlayer();

        this.rb.velocity = Vector3.zero;
        this.rb.angularVelocity = 0.0f;
        this.rb.AddForce(this.gameObject.transform.up * gm.standardEnemySpeed, ForceMode2D.Impulse);
    }

    private void NearPlayer()
    {
        this.rb.velocity = Vector3.zero;
        gm.standardEnemySpeed = 8f;
    }

    private void OutDetectionArea()
    {
        gm.standardEnemySpeed = 12f;
    }

    private Quaternion LookAtPlayer() => Quaternion.LookRotation(Vector3.forward, player.transform.position - this.transform.position);*/

    private GameObject player;
    private Rigidbody2D rb;
    GameManager gm;

    //public float movementSpeed = 200.0f;
    private bool followingPlayer = false;

    private void Awake()
    {
        this.player = GameObject.Find("Player");
        this.rb = this.gameObject.GetComponent<Rigidbody2D>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Start()
    {
        this.transform.rotation = LookAtPlayer();

        this.rb.AddForce(this.gameObject.transform.up * gm.standardEnemySpeed, ForceMode2D.Impulse);
    }

    private void FixedUpdate()
    {
        float distance = Vector2.Distance(this.transform.position, player.transform.position);

        if (distance > 50.0f)
            followingPlayer = false;

        if (followingPlayer)
            FollowPlayer();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "DetectionArea")
        {
            followingPlayer = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.name == "DetectionArea")
        {
            ResetMovement();
        }
    }

    private void FollowPlayer()
    {
        float zVelocity = 0.0f;
        float smoothTime = 0.2f;

        float rotZ = Mathf.SmoothDamp(this.transform.rotation.z, player.transform.rotation.z, ref zVelocity, smoothTime);
        this.transform.rotation = new Quaternion(this.transform.rotation.x, this.transform.rotation.y, rotZ, this.transform.rotation.w);

        this.rb.velocity = Vector3.zero;
        this.rb.angularVelocity = 0.0f;
        this.rb.AddForce(this.gameObject.transform.up * gm.standardEnemySpeed, ForceMode2D.Impulse);

        float distance = Vector2.Distance(this.transform.position, player.transform.position);

        if(distance <= gm.distanceFromThePlayer)
        {
            this.rb.velocity = Vector3.zero;
        }
    }

    private Quaternion LookAtPlayer() => Quaternion.LookRotation(Vector3.forward, player.transform.position - this.transform.position);

    private void ResetMovement()
    {
        followingPlayer = false;
        this.rb.velocity = Vector3.zero;
        this.rb.angularVelocity = 0.0f;

        this.rb.AddForce(this.gameObject.transform.up * gm.standardEnemySpeed, ForceMode2D.Impulse);
    }
}
