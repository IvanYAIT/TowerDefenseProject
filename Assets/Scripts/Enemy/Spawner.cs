using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : Object
{
    private Transform spawnpoin1;
    private Transform spawnpoin2;
    private GameObject NoramlEnemy;
    private GameObject HeavyEnemy;
    private GameObject SpeedEnemy;

    private int rndNum;
    private int rndEnemyNum;
    private float timer;
    private List<GameObject> enemies;
    private Slider progressBar;

    public Spawner(Transform spawnpoin1, Transform spawnpoin2, GameObject noramlEnemy, GameObject heavyEnemy, GameObject speedEnemy, Slider progressBar)
    {
        this.spawnpoin1 = spawnpoin1;
        this.spawnpoin2 = spawnpoin2;
        this.progressBar = progressBar;
        NoramlEnemy = noramlEnemy;
        HeavyEnemy = heavyEnemy;
        SpeedEnemy = speedEnemy;
        timer = 0;
        enemies = new List<GameObject>();
        enemies.Add(NoramlEnemy);
        enemies.Add(HeavyEnemy);
        enemies.Add(SpeedEnemy);
    }

    public void Spawn()
    {
        if (timer >= 1)
        {
            rndNum = Random.Range(1, 3);
            rndEnemyNum = Random.Range(0, 3);
            GameObject obj = null;
            if (rndNum == 1)
            {
                obj = Instantiate(enemies[rndEnemyNum], new Vector3(spawnpoin1.position.x, spawnpoin1.position.y, spawnpoin1.position.z), new Quaternion());
                obj.GetComponent<Enemy>().SetProgressBar(progressBar);
            }
            else
            {
                obj = Instantiate(enemies[rndEnemyNum], new Vector3(spawnpoin2.position.x, spawnpoin2.position.y, spawnpoin2.position.z), new Quaternion());
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
