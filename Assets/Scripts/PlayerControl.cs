using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    Rigidbody2D rb;
    public float planeSpeed = 10.0f;
    public float planeSpeedRotate = 1.0f;

    GameManager gm;

    void Awake()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
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
        PlayerFuelLoss();
        if(gm.playerFuel <= 0 )
        {
            PlayerDestroy();
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
        if (col.name == "carnister(Clone)")
        {
            if (gm.playerFuel <= 90)
            {
                PlayerFuelUpdata();
            }
            else
            {
                gm.playerFuel += 100 - gm.playerFuel;
            }
        }
        if (col.name == "hpicon(Clone)")
        {
            if (gm.playerHp <= 90)
            {
                PlayerHpUpdata();
            }
            else
            {
                gm.playerHp += 100 - gm.playerHp;
            }
        }
        if (col.name == "PowerUp(Clone)")
        {
            if (gm.playerDemage < 30)
            {
                PlayerDemageUpdata();
            }
        }
    }

    void PlayerHpLoss()
    {
        gm.playerHp -= gm.standardEnemyDemage;
    }

    void PlayerFuelLoss()
    {
        gm.playerFuel -= Time.deltaTime;
    }

    void PlayerDestroy()
    {
        Destroy(this.gameObject);
        Time.timeScale = 0;
    }

    void PlayerFuelUpdata()
    {
        gm.playerFuel += 10;
    }

    void PlayerHpUpdata()
    {
        gm.playerHp += 10;
    }

    void PlayerDemageUpdata()
    {
        gm.playerDemage += 5;
    }
}
