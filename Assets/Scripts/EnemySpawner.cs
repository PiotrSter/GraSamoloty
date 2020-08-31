using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject standardEnemy;
    public GameObject heavyEnemy;
    GameManager gm;
    public float timeToSpawnEnemy = 5f;
    public float spawnDelay;
    public int Wave = 1;

    void Awake()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Start()
    {
        spawnDelay = timeToSpawnEnemy;
    }

    void Update()
    {
        spawnDelay -= Time.deltaTime;
        if (spawnDelay <= 0)
        {
            SpawnEnemy();
            spawnDelay = timeToSpawnEnemy;
        }
    }

    void SpawnEnemy()
    {
        switch (Wave)
        {
            case 1:
                if (gm.howManyEnemysSpawn < 3)
                {
                    Instantiate(standardEnemy, new Vector3(-70f, 0, 0), Quaternion.identity);
                    gm.howManyEnemysSpawn++;
                    gm.howManyEnemysToKill++;
                }
                if (gm.howManyEnemysToKill == 0)
                {
                    Wave++;
                    gm.howManyEnemysSpawn = 0;
                }
                break;
            case 2:
                if (gm.howManyEnemysSpawn < 5)
                {
                    Instantiate(standardEnemy, new Vector3(0, 45f, 0), Quaternion.identity);
                    gm.howManyEnemysSpawn++;
                    gm.howManyEnemysToKill++;
                }
                if (gm.howManyEnemysToKill == 0)
                {
                    Wave++;
                    gm.howManyEnemysSpawn = 0;
                }
                break;
            case 3:
                if (gm.howManyEnemysSpawn < 5)
                {
                    Instantiate(standardEnemy, new Vector3(-70f, 0, 0), Quaternion.identity);
                    Instantiate(heavyEnemy, new Vector3(70f, 0, 0), Quaternion.identity);
                    gm.howManyEnemysSpawn += 2;
                    gm.howManyEnemysToKill += 2;
                }
                if (gm.howManyEnemysToKill == 0)
                {
                    Wave++;
                    gm.howManyEnemysSpawn = 0;
                }
                break;
            case 4:
                Debug.Log("Fala 4");
                break;
        }
    }
}
