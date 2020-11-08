using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    Rigidbody2D rb;
    public float planeSpeed = 12.0f;
    public float planeSpeedRotate = 1.0f;
    public GameObject pointer;

    GameManager gm;

    void Awake()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        //Instantiate(pointer, new Vector3(transform.position.x + 11f, transform.position.y + 0.7f, transform.position.z), transform.rotation);
    }

    void Update()
    {       
        if (Input.GetKey(KeyCode.W))
        {
            this.rb.velocity = transform.up * planeSpeed;
            PlayerFuelLoss();
        }
        else
        {
            this.rb.velocity = transform.up * gm.speedWithOutForce;
        }
        if (gm.pause == false)
        {
            if (Input.GetKey(KeyCode.A))
            {
                this.gameObject.transform.Rotate(new Vector3(0, 0, planeSpeedRotate));
            }
            if (Input.GetKey(KeyCode.D))
            {
                this.gameObject.transform.Rotate(new Vector3(0, 0, -planeSpeedRotate));
            }
        }
        if(gm.playerFuel <= 0 )
        {
            PlayerDestroy();
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "BulletEnemy(Clone)")
        {
            PlayerHpLoss();
            if(gm.playerHp <= 0)
            {
                PlayerDestroy();
            }
        }
        if (col.name == "carnister(Clone)")
        {
            if (gm.playerFuel <= 190)
            {
                PlayerFuelUpdata();
            }
            else
            {
                gm.playerFuel += 200 - gm.playerFuel;
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
        gm.gameOver = true;
        Time.timeScale = 0;
        gm.GameOverPanel.SetActive(true);
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
