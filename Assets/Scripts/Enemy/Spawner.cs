using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
    private TextMeshProUGUI waveText;

    public Spawner(List<Transform> spawnpoints, List<WaveData> waveDatas, Slider progressBar, List<GameObject> enemies, bool isLvl0, float waveDelay, TextMeshProUGUI waveText)
    {
        this.spawnpoints = spawnpoints;
        this.progressBar = progressBar;
        this.waveDatas = waveDatas;
        this.waveDelay = waveDelay;
        this.enemies = enemies;
        this.isLvl0 = isLvl0;
        this.waveText = waveText;
        waveText.text = (waveCounter+1).ToString();
        currentWave = waveDatas[0];
        foreach (WaveData data in waveDatas)
        {
            progressBar.maxValue += data.NormalEnemyCount + data.HeavyEnemyCount + data.FlyingEnemyCount;
        }
        progressBar.maxValue -= 1;
    }

    private void SpawnEnemy(int indexOfSpawnpoint, int indexOfEnemy)
    {
        if (spawnpoints[indexOfSpawnpoint].childCount == 0)
        {
            GameObject obj = Instantiate(enemies[indexOfEnemy], spawnpoints[indexOfSpawnpoint].position, new Quaternion());
            obj.GetComponent<Enemy>().SetProgressBar(progressBar);
            enemyGeneralCounter++;
            enemyLocalCounter++;
            if (indexOfEnemy == 0)
                normalEnemyCounter++;
            else if (indexOfEnemy == 1)
                heavyEnemyCounter++;
            else if (indexOfEnemy == 2)
                flyingEnemyCounter++;
        }
    }

    public void Spawn()
    {
        
        if (waveDelayTimer >= waveDelay)
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
                            if (currentWave.IsMixed)
                                SpawnEnemy(Random.Range(0, 3), 0);
                            else
                                SpawnEnemy(0, 0);

                        }
                        if (heavyEnemyCounter < currentWave.HeavyEnemyCount)
                        {
                            if (currentWave.IsMixed)
                                SpawnEnemy(Random.Range(0, 3), 1);
                            else
                                SpawnEnemy(1, 1);
                        }
                        if (flyingEnemyCounter < currentWave.FlyingEnemyCount)
                        {
                            if (currentWave.IsMixed)
                                SpawnEnemy(Random.Range(0, 3), 2);
                            else
                                SpawnEnemy(2, 2);
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
                        waveText.text = (waveCounter + 1).ToString();
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