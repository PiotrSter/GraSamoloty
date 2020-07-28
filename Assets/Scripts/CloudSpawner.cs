using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    public GameManager gm;
    public GameObject[] Clouds = new GameObject[4];
    public float spawnDelay;
    public float cloudSpawnDelay = 7f;

    void Awake()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        spawnDelay -= Time.deltaTime;
        if(spawnDelay <= 0)
        {
            if (gm.howManyClouds < 5)
            {
                spawnCloud();
                spawnDelay = cloudSpawnDelay;
            }
        }
    }

    void spawnCloud()
    {
        float randomY = Random.Range(-35.5f, 35.5f);
        int randomIndex = Random.Range(0, 4);
        Instantiate(Clouds[randomIndex], new Vector3(-109, randomY, 0), Quaternion.identity);
        gm.howManyClouds += 1;
    }
}
