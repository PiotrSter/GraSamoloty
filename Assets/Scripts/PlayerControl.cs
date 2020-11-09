using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    Rigidbody2D rb;
    public float planeSpeed = 12.0f;
    public float planeSpeedRotate = 1.0f;
    public GameObject pointer;
    ShotBullet bulletShot;

    GameManager gm;

    public delegate void onPlayerDetectionTriggerEnter2DDelegate(Collider2D col);
    public onPlayerDetectionTriggerEnter2DDelegate onPlayerDetectionTriggerEnter2D;

    public delegate void onPlayerDetectionTriggerExit2DDelegate(Collider2D col);
    public onPlayerDetectionTriggerExit2DDelegate onPlayerDetectionTriggerExit2D;

    void Awake()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        onPlayerDetectionTriggerEnter2D = new onPlayerDetectionTriggerEnter2DDelegate(OnPlayerDetectionTriggerEnter2D);
        onPlayerDetectionTriggerExit2D = new onPlayerDetectionTriggerExit2DDelegate(OnPlayerDetectionTriggerExit2D);
        bulletShot = GameObject.Find("ShotSpawn").GetComponent<ShotBullet>();
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

    void OnPlayerDetectionTriggerEnter2D(Collider2D col)
    {
        if (col.name == "BulletEnemy(Clone)")
        {
            PlayerHpLoss();
            if (gm.playerHp <= 0)
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
        if (col.gameObject.tag == "Enemy")
        {
            this.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);
            bulletShot.canShoot = false;
        }
        if (col.gameObject.tag == "Boss")
        {
            this.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);
            bulletShot.canShoot = false;
        }
    }

    void OnPlayerDetectionTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.tag == "Enemy")
        {
            this.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            bulletShot.canShoot = true;
        }
        if (col.gameObject.tag == "Boss")
        {
            this.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            bulletShot.canShoot = true;
        }
    }

    public void PlayerHpLoss()
    {
        gm.playerHp -= gm.standardEnemyDemage;
    }

    void PlayerFuelLoss()
    {
        gm.playerFuel -= Time.deltaTime;
    }

    public void PlayerDestroy()
    {
        Destroy(this.gameObject);
        gm.gameOver = true;
        Time.timeScale = 0;
        gm.GameOverPanel.SetActive(true);
    }

    public void PlayerFuelUpdata()
    {
        gm.playerFuel += 10;
    }

    public void PlayerHpUpdata()
    {
        gm.playerHp += 10;
    }

    public void PlayerDemageUpdata()
    {
        gm.playerDemage += 5;
    }

}
