using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    //public GameManager gm;
    public GameObject cloudOne;
    public GameObject cloudTwo;
    public GameObject cloudThree;
    public GameObject cloudFour;
    public GameObject[] Clouds = new GameObject[4];
    public float spawnDelay;
    public float cloudSpawnDelay = 20f;

    void Awake()
    {
        //gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        Clouds[0] = cloudOne;
        Clouds[1] = cloudTwo;
        Clouds[2] = cloudThree;
        Clouds[3] = cloudFour;
    }

    void Update()
    {
        spawnDelay -= Time.deltaTime;
        if(spawnDelay <= 0)
        {
            spawnCloud();
            spawnDelay = cloudSpawnDelay;
        }
    }

    void spawnCloud()
    {
        float randomY = Random.Range(-35.5f, 35.5f);
        int randomIndex = Random.Range(0, 4);
        Instantiate(Clouds[randomIndex], new Vector3(-109, randomY, 0), Quaternion.identity);
    }
}
