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

    void Updata()
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
        if (obj.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }

    void BoostDestroy()
    {
        Destroy(this.gameObject);
    }
}
