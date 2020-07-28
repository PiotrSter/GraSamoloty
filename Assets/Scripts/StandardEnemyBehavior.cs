using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardEnemyBehavior : MonoBehaviour
{
    Rigidbody2D rb;
    GameManager gm;
    private Transform playerPosition;
    private Transform enemy;
    float distance;
    //public GameObject player;
    //public Vector3 enemyPosition;

    void Start()
    {
        enemy = transform;
        GameObject player = GameObject.FindWithTag("Player");
        playerPosition = player.transform;
    }

    void Awake()
    {      
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();        
    }

    void Update()
    {
        distance = Vector2.Distance(enemy.position, playerPosition.position);
        if (distance <= 20 && distance > gm.distanceFromThePlayer)
        {
            Quaternion rotation = Quaternion.LookRotation(playerPosition.position - enemy.position);
            float oryginalX = transform.rotation.x;
            float oryginalY = transform.rotation.y;
            Quaternion finalRotation = Quaternion.Slerp(enemy.transform.rotation, rotation, gm.standardEnemySpeedRotate * Time.deltaTime);
            finalRotation.x = oryginalX;
            finalRotation.y = oryginalY;
            transform.rotation = finalRotation;
            //enemy.rotation = Quaternion.Slerp(enemy.rotation, Quaternion.LookRotation(playerPosition.position - enemy.position), gm.standardEnemySpeedRotate * Time.deltaTime);
            //enemy.position += enemy.forward * gm.standardEnemySpeed * Time.deltaTime;
        }
        else
        {
            //this.rb.velocity = Vector2.zero;
            //transform.Translate(Vector3.forward * gm.standardEnemySpeed * Time.deltaTime);
            //enemyPosition = Vector3.Lerp(transform.position, player.transform.position, Time.fixedDeltaTime * gm.standardEnemySpeed);
            //transform.position = new Vector3(enemyPosition.x - 10, enemyPosition.y, 0);
        }
    }
    /*
    void OnTriggerEnter2D(Collider2D obj)
    {
        if(obj.gameObject.tag == "Player")
        {
            enemyPosition = Vector3.Lerp(transform.position, player.transform.position, Time.fixedDeltaTime * gm.standardEnemySpeed);
        }
    }
    */
}
