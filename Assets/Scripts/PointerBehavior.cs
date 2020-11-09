using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerBehavior : MonoBehaviour
{
    private GameObject player;
    private GameManager gm;
    private GameObject enemyTarget;

    void Awake()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        this.player = GameObject.Find("Player");
        transform.SetParent(player.transform);
        this.gameObject.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, 0f);
    }

    
    void Update()
    {
        if (gm.listEnemy.Count() > 0)
        {
            FindMin();
            this.transform.rotation = FindEnemy();
        }
    }

    private void FindMin()
    {

            enemyTarget = gm.listEnemy.FirstOrDefault().gameObject;

            foreach (GameObject enemy in gm.listEnemy)
            {
                if (enemy.GetComponent<EnemyBehavior>().distance < enemyTarget.GetComponent<EnemyBehavior>().distance)
                {
                    enemyTarget = enemy;
                }
            }

    }

    private Quaternion FindEnemy()
    {
        if (enemyTarget.GetComponent<EnemyBehavior>().distance < 20)
        {
            this.gameObject.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, 0f);
        }
        else
        {
            this.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        }
        return Quaternion.LookRotation(Vector3.forward, enemyTarget.transform.position - this.transform.position);
    }
}
