using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpBelt : MonoBehaviour
{
    private float maxHp = 100f;
    GameManager gm;
    //public Texture2D healthTexture;

    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void OnGUI()
    {
        this.transform.localScale = new Vector3(gm.playerHp / maxHp, 1, 0);
        //GUI.DrawTexture(new Rect(10, 10, gm.playerHp * 100 / maxHp, 20), healthTexture);
    }
}
