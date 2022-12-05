using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WaveData", menuName = "SO/NewWaveData")]
public class WaveData : ScriptableObject
{
    [SerializeField] private int timeBetweenSpawnEnemy;
    [SerializeField] private List<GameObject> whatEnemies;
    [SerializeField] private int enemyCount;

    public int TimeBetweenSpawnEnemy => timeBetweenSpawnEnemy;
    public int EnemyCount => enemyCount;
    public List<GameObject> WhatEnemies => whatEnemies;
}
