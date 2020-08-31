﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float bulletSpeed = 30.0f;
    public float cloudSpeed = 5f;
    public int howManyClouds = 0;
    public int howManyEnemysSpawn = 0;
    public int howManyEnemysToKill = 0;
    public float standardEnemySpeed = 10f;
    public float heavyEnemySpeed = 7f;
    public float distanceFromThePlayer = 10f;
    public int playerHp = 100;
    public float playerFuel = 100f;
    public int playerDemage = 10;
    public int standardEnemyDemage = 10;
    public HpBar hpBar;
    public FuelLevel fuelBar;
    public Text shotPowerText;

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
}
