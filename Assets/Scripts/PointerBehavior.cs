using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerBehavior : MonoBehaviour
{
    private GameObject enemy;
    private GameObject player;

    void Start()
    {
        this.enemy = GameObject.FindGameObjectWithTag("Enemy");
        this.player = GameObject.Find("Player");
        transform.SetParent(player.transform);
    }

    
    void Update()
    {
        this.transform.rotation = FindEnemy();
    }

    private Quaternion FindEnemy() => Quaternion.LookRotation(Vector3.forward, enemy.transform.position - this.transform.position);
}
