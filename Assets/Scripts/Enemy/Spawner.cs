using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : Object
{
    private List<Transform> spawnpoints;
    private int rndNum;
    private int rndEnemyNum;
    private float timer;
    private List<GameObject> enemies;
    private Slider progressBar;
    private bool isLvl0;

    public Spawner(List<Transform> spawnpoints, List<GameObject> enemies, Slider progressBar, bool isLvl0)
    {
        this.spawnpoints = spawnpoints;
        this.progressBar = progressBar;
        this.enemies = enemies;
        this.isLvl0 = isLvl0;
        timer = 0;
    }

    public void Spawn()
    {
        if (timer >= 1)
        {
            rndNum = Random.Range(0, spawnpoints.Count);

            if(spawnpoints[rndNum].childCount != 0)
            {
                spawnpoints[rndNum].GetChild(0).gameObject.SetActive(true);
            }
            else
            {
                rndEnemyNum = Random.Range(0, 3);

                GameObject obj = Instantiate(enemies[rndEnemyNum], spawnpoints[rndNum].position, new Quaternion());
                obj.GetComponent<Enemy>().SetProgressBar(progressBar);
            }
            timer = 0;
        }
        else
        {
            timer += Time.deltaTime;
        }
    }
}
