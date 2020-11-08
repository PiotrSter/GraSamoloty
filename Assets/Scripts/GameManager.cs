using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float bulletSpeed = 30.0f;
    public float cloudSpeed = 5f;
    public int howManyClouds = 0;
    public int howManyEnemysSpawn = 0;
    public int howManyEnemysToKill = 0;
    public float distanceFromThePlayer = 10f;
    public int playerHp = 100;
    public float playerFuel = 100f;
    public int playerDemage = 10;
    public int standardEnemyDemage = 10;
    public float speedWithOutForce = 5f;
    public HpBar hpBar;
    public FuelLevel fuelBar;
    public Text shotPowerText;
    public GameObject EndLevelPanel;
    public GameObject GameOverPanel;
    public GameObject PausePanel;
    public bool gameOver = false;
    public bool pause = false;
    public List<GameObject> listEnemy;

    void Start()
    {
        hpBar.SetMaxHealth(playerHp);
        fuelBar.SetMaxFuel(playerFuel);
    }

    void Update()
    {
        hpBar.SetHealth(playerHp);
        fuelBar.SetFuel(playerFuel);
        shotPowerText.text = "Shot Power " + playerDemage + "/30";
    }

    public void MenuButton()
    {
        SceneManager.LoadScene(0);
    }

    public void TryAgainButton()
    {
        SceneManager.LoadScene(1);
    }
}
