using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    public GameObject standardEnemy;
    public GameObject heavyEnemy;
    GameManager gm;
    public float timeToSpawnEnemy = 5f;
    public float spawnDelay;
    public int Wave = 1;
    public Text waveText;
    public float timeToDestroyText = 5f;
    public float textDestroyDelay;

    void Awake()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Start()
    {
        spawnDelay = timeToSpawnEnemy;
        textDestroyDelay = timeToDestroyText;
    }

    void Update()
    {
        spawnDelay -= Time.deltaTime;
        if (spawnDelay <= 0)
        {
            SpawnEnemy();
            spawnDelay = timeToSpawnEnemy;
        }
        textDestroyDelay -= Time.deltaTime;
        if (textDestroyDelay > 0)
        {
            waveText.text = "Fala " + Wave;
        }
        else
        {
            waveText.text = " ";
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
                    textDestroyDelay = timeToDestroyText;
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
                    textDestroyDelay = timeToDestroyText;
                }
                break;
            case 3:
                if (gm.howManyEnemysSpawn < 5)
                {
                    Instantiate(standardEnemy, new Vector3(-70f, 0, 0), Quaternion.identity);                    
                    gm.howManyEnemysSpawn++;
                    gm.howManyEnemysToKill++;
                }
                if (gm.howManyEnemysSpawn < 5)
                {
                    Instantiate(heavyEnemy, new Vector3(70f, 0, 0), Quaternion.identity);
                    gm.howManyEnemysSpawn++;
                    gm.howManyEnemysToKill++;
                }
                if (gm.howManyEnemysToKill == 0)
                {
                    Wave++;
                    gm.howManyEnemysSpawn = 0;
                    textDestroyDelay = timeToDestroyText;
                }
                break;
            case 4:
                if (gm.howManyEnemysSpawn < 5)
                {
                    Instantiate(heavyEnemy, new Vector3(0, -43f, 0), Quaternion.identity);
                    gm.howManyEnemysSpawn++;
                    gm.howManyEnemysToKill++;
                }
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
                    textDestroyDelay = timeToDestroyText;
                }
                break;
            case 5:
                if (gm.howManyEnemysSpawn < 7)
                {
                    Instantiate(standardEnemy, new Vector3(-70f, 0, 0), Quaternion.identity);
                    gm.howManyEnemysSpawn++;
                    gm.howManyEnemysToKill++;
                }
                if (gm.howManyEnemysSpawn < 7)
                {
                    Instantiate(heavyEnemy, new Vector3(70f, 0, 0), Quaternion.identity);
                    gm.howManyEnemysSpawn++;
                    gm.howManyEnemysToKill++;
                }
                break;
        }
    }
}
