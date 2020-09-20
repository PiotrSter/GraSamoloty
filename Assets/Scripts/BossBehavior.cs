using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehavior : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    GameManager gm;
    public int bossHp = 500;

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

        if (col.name == "Bullet(Clone)")
        {
            HpLoss();
            if (bossHp <= 0)
            {
                BossDestroy();
            }
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

        if (distance <= gm.distanceFromThePlayer)
        {
            this.rb.velocity = this.gameObject.transform.up * gm.speedWithOutForce;
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

    void HpLoss()
    {
        bossHp -= gm.playerDemage;
    }

    void BossDestroy()
    {
        Destroy(this.gameObject);
    }

}
