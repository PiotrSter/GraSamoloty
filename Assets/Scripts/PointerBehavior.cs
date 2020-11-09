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
        return Quaternion.LookRotation(Vector3.forward, enemyTarget.transform.position - this.transform.position);
    }
}
