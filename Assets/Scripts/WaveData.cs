using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WaveData", menuName = "SO/NewWaveData")]
public class WaveData : ScriptableObject
{
    [SerializeField] private float timeBetweenSpawnEnemy;
    [SerializeField] private List<GameObject> whatEnemies;
    [SerializeField] private int normalEnemyCount;
    [SerializeField] private int heavyEnemyCount;
    [SerializeField] private int flyingEnemyCount;

    public float TimeBetweenSpawnEnemy => timeBetweenSpawnEnemy;
    public int NormalEnemyCount => normalEnemyCount;
    public int HeavyEnemyCount => heavyEnemyCount;
    public int FlyingEnemyCount => flyingEnemyCount;
    public List<GameObject> WhatEnemies => whatEnemies;
}
