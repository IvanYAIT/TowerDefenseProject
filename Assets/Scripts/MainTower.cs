using State;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainTower : MonoBehaviour, IDamagable
{
    [SerializeField] private int hp;

    public static Action<Type> OnTowerDestroy;

    void Update()
    {
        if (hp <= 0)
            OnTowerDestroy?.Invoke(typeof(LoseState));
    }

    public void GetDamage(int damage)
    {
        hp -= damage;
    }
}
