using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public Transform playerTransform;
    private float cameraOffset = -10f;

    GameManager gm;

    void Awake()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        if (gm.gameOver == false)
        {
            transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, cameraOffset);
        }
    }
}
