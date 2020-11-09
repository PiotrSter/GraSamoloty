using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostsBehavior : MonoBehaviour
{
    public float destroyDelay;
    public float boostDestroyDelay = 20f;

    void Start()
    {
        destroyDelay = boostDestroyDelay;
    }

    void Update()
    {
        destroyDelay -= Time.deltaTime;
        if(destroyDelay <= 0)
        {
            BoostDestroy();
            destroyDelay = boostDestroyDelay;
        }
    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.name == "PlayerDetection")
        {
            BoostDestroy();
        }
    }

    void BoostDestroy()
    {
        Destroy(this.gameObject);
    }
}
