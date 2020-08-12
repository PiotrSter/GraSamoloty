using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    GameObject standardEnemy;
    GameManager gm;
    public float timeToSpawnEnemy = 5f;
    public float spawnDelay;
    private int Wave = 1;

    void Awake()
    {
        standardEnemy = GameObject.Find("StandardEnemy");
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Start()
    {
        spawnDelay = timeToSpawnEnemy;
    }

    void Update()
    {
        if (gm.howManyEnemys <= 5)
        {
            spawnDelay -= Time.deltaTime;
            if (spawnDelay <= 0)
            {
                SpawnEnemy();
                spawnDelay = timeToSpawnEnemy;
            }
        }
        else
        {
            Wave++;
        }
    }

    void SpawnEnemy()
    {
        switch (Wave)
        {
            case 1:
                Instantiate(standardEnemy, new Vector3(-70f, 0, 0), Quaternion.identity);
                break;
        }
    }
}
