using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform spawnpoin1;
    [SerializeField] private Transform spawnpoin2;
    [SerializeField] private GameObject NoramlEnemy;
    [SerializeField] private GameObject HeavyEnemy;
    [SerializeField] private GameObject SpeedEnemy;

    private int rndNum;
    private int rndEnemyNum;
    private float timer;
    private List<GameObject> enemies;

    void Start()
    {
        timer = 0;
        enemies = new List<GameObject>();
        enemies.Add(NoramlEnemy);
        enemies.Add(HeavyEnemy);
        enemies.Add(SpeedEnemy);
    }


    void Update()
    {
        if(timer >= 1)
        {
            rndNum = Random.Range(1, 3);
            rndEnemyNum = Random.Range(0, 3);
            if (rndNum == 1)
            {
                Instantiate(enemies[rndEnemyNum], new Vector3(spawnpoin1.position.x, spawnpoin1.position.y, spawnpoin1.position.z), new Quaternion());
            }
            else
            {
                Instantiate(enemies[rndEnemyNum], new Vector3(spawnpoin2.position.x, spawnpoin2.position.y, spawnpoin2.position.z), new Quaternion());
            }
            timer = 0;
        }
        else
        {
            timer += Time.deltaTime;
        }
        
    }
}
