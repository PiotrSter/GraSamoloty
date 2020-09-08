using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardEnemyBehavior : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    GameManager gm;
    public int enemyHp = 20;
    public GameObject[] Boosts = new GameObject[3];

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
            if (enemyHp <= 0)
            {
                SpawnBoost();
                EnemyDestroy();                
            }
        }

        /*if (col.name == "DetectionEnemyArea")
        {
            this.transform.rotation = Quaternion.LookRotation(Vector3.forward, new Vector3(0, 0, 90) - this.transform.position);
        }*/
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.name == "DetectionArea")
        {
            ResetMovement();
        }

        /*if (col.name == "DetectionEnemyArea")
        {
            ResetMovement();
        }*/
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

    void HpLoss()
    {
        enemyHp -= gm.playerDemage;
    }

    void EnemyDestroy()
    {
        gm.howManyEnemysToKill--;
        Destroy(this.gameObject);
    }

    void SpawnBoost()
    {
        int randomIndex = Random.Range(0, 3);
        Instantiate(Boosts[randomIndex], transform.position, transform.rotation);
    }
}
