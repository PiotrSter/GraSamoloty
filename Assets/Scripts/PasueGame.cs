using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasueGame : MonoBehaviour
{
    private float tempTimeScale;
    GameManager gm;

    void Awake()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale != 0)
            {
                tempTimeScale = Time.timeScale;
            }
            Pause();
        }
    }

    void Pause()
    {
        gm.PausePanel.SetActive(!gm.PausePanel.activeInHierarchy);
        if(Time.timeScale != 0)
        {
            gm.pause = true;
            Time.timeScale = 0;
        }
        else
        {
            gm.pause = false;
            Time.timeScale = tempTimeScale;
        }
    }

    public void ReasumeButton()
    {
        Pause();
    }
}
