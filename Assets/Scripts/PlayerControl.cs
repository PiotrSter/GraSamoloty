using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    Rigidbody2D rb;
    public float planeSpeed = 10.0f;
    public float planeSpeedRotate = 1.0f;

    public HpBar hpBar;
    GameManager gm;

    void Awake()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Start()
    {
        hpBar.SetMaxHealth(gm.playerHp);
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

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "BulletEnemy Variant(Clone)")
        {
            PlayerHpLoss();
            if(gm.playerHp <= 0)
            {
                PlayerDestroy();
            }
        }
    }

    void PlayerHpLoss()
    {
        gm.playerHp -= gm.standardEnemyDemage;
        hpBar.SetHealth(gm.playerHp);

    }

    void PlayerDestroy()
    {
        Destroy(this.gameObject);
        Time.timeScale = 0;
    }
}
