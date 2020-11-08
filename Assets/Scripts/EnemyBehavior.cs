using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBehavior : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    GameManager gm;
    public int enemyHp;
    public float enemySpeed;
    public GameObject[] Boosts = new GameObject[5];
    public float distance;

    public bool followingPlayer = false;

    public void Awake()
    {
        this.player = GameObject.Find("Player");
        this.rb = this.gameObject.GetComponent<Rigidbody2D>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        gm.listEnemy.Add(this.gameObject);
    }

    public void Start()
    {
        this.transform.rotation = LookAtPlayer();

        this.rb.AddForce(this.gameObject.transform.up * enemySpeed, ForceMode2D.Impulse);
    }

    public void FixedUpdate()
    {
        distance = Vector2.Distance(this.transform.position, player.transform.position);

        if (distance > 50.0f)
            followingPlayer = false;

        if (followingPlayer)
            FollowPlayer();
    }

    public void OnTriggerEnter2D(Collider2D col)
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

        if (col.gameObject.tag == "Enemy")
        {
            this.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);
        }

    }

    public void OnTriggerExit2D(Collider2D col)
    {
        if (col.name == "DetectionArea")
        {
            ResetMovement();
        }

        if (col.gameObject.tag == "Enemy")
        {
            this.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        }
    }

    public void FollowPlayer()
    {
        float zVelocity = 0.0f;
        float smoothTime = 0.2f;

        float rotZ = Mathf.SmoothDamp(this.transform.rotation.z, player.transform.rotation.z, ref zVelocity, smoothTime);
        this.transform.rotation = new Quaternion(this.transform.rotation.x, this.transform.rotation.y, rotZ, this.transform.rotation.w);

        this.rb.velocity = Vector3.zero;
        this.rb.angularVelocity = 0.0f;
        this.rb.AddForce(this.gameObject.transform.up * enemySpeed, ForceMode2D.Impulse);

        float distance = Vector2.Distance(this.transform.position, player.transform.position);

        if(distance <= gm.distanceFromThePlayer)
        {
            this.rb.velocity = this.gameObject.transform.up * gm.speedWithOutForce; 
        }
    }

    public Quaternion LookAtPlayer() => Quaternion.LookRotation(Vector3.forward, player.transform.position - this.transform.position);

    public void ResetMovement()
    {
        followingPlayer = false;
        this.rb.velocity = Vector3.zero;
        this.rb.angularVelocity = 0.0f;

        this.rb.AddForce(this.gameObject.transform.up * enemySpeed, ForceMode2D.Impulse);
    }

    public void HpLoss()
    {
        enemyHp -= gm.playerDemage;
    }

    public void EnemyDestroy()
    {
        gm.howManyEnemysToKill--;
        gm.listEnemy.Remove(this.gameObject);
        Destroy(this.gameObject);
    }

    public void SpawnBoost()
    {
        int randomIndex = Random.Range(0, 3);
        Instantiate(Boosts[randomIndex], transform.position, transform.rotation);
    }

}
