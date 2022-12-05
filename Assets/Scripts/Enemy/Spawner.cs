using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : Object
{
    private List<Transform> spawnpoints;
    private int rndEnemyNum;
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

    public Spawner(List<Transform> spawnpoints, List<WaveData> waveDatas, Slider progressBar, bool isLvl0)
    {
        this.spawnpoints = spawnpoints;
        this.progressBar = progressBar;
        this.waveDatas = waveDatas;
        enemies = waveDatas[0].WhatEnemies;
        this.isLvl0 = isLvl0;
        currentWave = waveDatas[0];
        spawnpoints[spawnpointCounter].GetChild(0).gameObject.SetActive(true);
    }

    public void Spawn()
    {
        if (enemyGeneralCounter != progressBar.maxValue)
        {
            if (enemyLocalCounter < currentWave.EnemyCount)
            {
                if (timer >= currentWave.TimeBetweenSpawnEnemy)
                {
                    if (spawnpoints[spawnpointCounter].childCount == 0)
                    {
                        rndEnemyNum = Random.Range(0, enemies.Count);
                        EnemyType currentEnemyType = enemies[rndEnemyNum].GetComponent<Enemy>().EnemyType;

                        if(currentEnemyType.Equals(EnemyType.Normal))
                        {
                            GameObject obj = Instantiate(enemies[rndEnemyNum], spawnpoints[0].position, new Quaternion());
                            obj.GetComponent<Enemy>().SetProgressBar(progressBar);
                        } else if(currentEnemyType.Equals(EnemyType.Flying))
                        {
                            GameObject obj = Instantiate(enemies[rndEnemyNum], spawnpoints[1].position, new Quaternion());
                            obj.GetComponent<Enemy>().SetProgressBar(progressBar);
                        } else if(currentEnemyType.Equals(EnemyType.Heavy))
                        {
                            GameObject obj = Instantiate(enemies[rndEnemyNum], spawnpoints[2].position, new Quaternion());
                            obj.GetComponent<Enemy>().SetProgressBar(progressBar);
                        }

                        enemyGeneralCounter++;
                        enemyLocalCounter++;
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
                enemyLocalCounter = 0;
                waveCounter++;
                spawnpointCounter++;
                if (spawnpoints.Count > spawnpointCounter)
                {
                    if (spawnpoints[spawnpointCounter].childCount != 0)
                    {
                        for (int i = 0; i < enemies.Count; i++)
                        {
                            EnemyType currentEnemyType = enemies[i].GetComponent<Enemy>().EnemyType;
                            if (currentEnemyType.Equals(EnemyType.Flying))
                            {
                                spawnpoints[1].GetChild(0).gameObject.SetActive(true);
                            }
                            else if (currentEnemyType.Equals(EnemyType.Heavy))
                            {
                                spawnpoints[2].GetChild(0).gameObject.SetActive(true);
                            }
                        }
                    }
                }
                currentWave = waveDatas[waveCounter];
                enemies = waveDatas[waveCounter].WhatEnemies;
            }
        }
    }
}
