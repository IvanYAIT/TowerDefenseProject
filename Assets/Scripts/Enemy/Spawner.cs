using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : Object
{
    private List<Transform> spawnpoints;
    private int normalEnemyCounter;
    private int heavyEnemyCounter;
    private int flyingEnemyCounter;
    private float timer = 0;
    private List<GameObject> enemies;
    private Slider progressBar;
    private bool isLvl0;
    private int enemyGeneralCounter = 0;
    private int enemyLocalCounter = 0;
    private List<WaveData> waveDatas;
    private WaveData currentWave;
    private int waveCounter = 0;
    private int spawnpointCounter = 0;
    private float waveDelay;
    private float waveDelayTimer = 0;
    private bool first = true;

    public Spawner(List<Transform> spawnpoints, List<WaveData> waveDatas, Slider progressBar, bool isLvl0, float waveDelay)
    {
        this.spawnpoints = spawnpoints;
        this.progressBar = progressBar;
        this.waveDatas = waveDatas;
        this.waveDelay = waveDelay;
        enemies = waveDatas[0].WhatEnemies;
        this.isLvl0 = isLvl0;
        currentWave = waveDatas[0];
    }

    private void SpawnNormalEnemy()
    {
        if (spawnpoints[0].childCount == 0)
        {
            GameObject obj = Instantiate(enemies[0], spawnpoints[0].position, new Quaternion());
            obj.GetComponent<Enemy>().SetProgressBar(progressBar);
            enemyGeneralCounter++;
            enemyLocalCounter++;
            normalEnemyCounter++;
        }
    }
    private void SpawnHeavyEnemy()
    {
        if (spawnpoints[1].childCount == 0)
        {
            GameObject obj = Instantiate(enemies[1], spawnpoints[1].position, new Quaternion());
            obj.GetComponent<Enemy>().SetProgressBar(progressBar);
            enemyGeneralCounter++;
            enemyLocalCounter++;
            heavyEnemyCounter++;
        }
    }
    private void SpawnFlyingEnemy()
    {
        if (spawnpoints[2].childCount == 0)
        {
            GameObject obj = Instantiate(enemies[2], spawnpoints[2].position, new Quaternion());
            obj.GetComponent<Enemy>().SetProgressBar(progressBar);
            enemyGeneralCounter++;
            enemyLocalCounter++;
            flyingEnemyCounter++;
        }
    }

    public void Spawn()
    {
        if(waveDelayTimer >= waveDelay)
        {
            if (first)
            {
                spawnpoints[0].GetChild(0).gameObject.SetActive(true);
                first = false;
            }
            if (enemyGeneralCounter != progressBar.maxValue)
            {
                int enemyCount = currentWave.NormalEnemyCount + currentWave.HeavyEnemyCount + currentWave.FlyingEnemyCount;
                if (enemyLocalCounter < enemyCount)
                {
                    if (timer >= currentWave.TimeBetweenSpawnEnemy)
                    {
                        if (normalEnemyCounter < currentWave.NormalEnemyCount)
                        {
                            SpawnNormalEnemy();
                        }
                        if (heavyEnemyCounter < currentWave.HeavyEnemyCount)
                        {
                            SpawnHeavyEnemy();
                        }
                        if (flyingEnemyCounter < currentWave.FlyingEnemyCount)
                        {
                            SpawnFlyingEnemy();
                        }
                        timer = 0;
                    }
                    else
                    {
                        timer += Time.deltaTime;
                    }
                }
                else
                {
                    waveCounter++;
                    if (waveCounter < waveDatas.Count)
                    {
                        enemyLocalCounter = 0;
                        normalEnemyCounter = 0;
                        heavyEnemyCounter = 0;
                        flyingEnemyCounter = 0;
                        spawnpointCounter++;
                        if (spawnpoints.Count > spawnpointCounter)
                        {
                            spawnpoints[spawnpointCounter].GetChild(0).gameObject.SetActive(true);
                        }
                        currentWave = waveDatas[waveCounter];
                        enemies = waveDatas[waveCounter].WhatEnemies;
                    }
                }
            }
        }
        else
        {
            waveDelayTimer += Time.deltaTime;
        }
        
    }
}