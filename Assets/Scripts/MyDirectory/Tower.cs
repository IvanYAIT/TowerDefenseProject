using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tower : MonoBehaviour
{
    [SerializeField] public int Cost = 0;
    [SerializeField] private float Culldown, Curcooldown = 0;
    [SerializeField] private int Power = 0;
    [SerializeField] private int Radius = 0;
    [SerializeField] public int MoneyForLevelUp = 0;
    [SerializeField] private GameObject ShownObject;
    [SerializeField] private Text TextMoney;
    private int counter = 0;
    [SerializeField] private float[] LevelUpCulldown;
    [SerializeField] private int[] LevelupPower;
    [SerializeField] private int[] LevelUpRadius;
    [SerializeField] private int[] NeededMoneyForLevelUp;
    [SerializeField] private bool Using;
    [SerializeField] private GameObject Projectile;
    [SerializeField] private bool CabBeatFlingEnemies;

    public void ShowAbilityToLevelUp()
    {
        ShownObject?.SetActive(true);
    }

    public void StopShowAbilityToLevelUp()
    {
        ShownObject?.SetActive(false);
    }

    public void LevelUp()
    {
        Power += LevelupPower[counter];
        Radius += LevelUpRadius[counter];
        Culldown -= LevelUpCulldown[counter];
        MoneyForLevelUp += NeededMoneyForLevelUp[counter];
        counter++;
    }

    private void Update()
    {
        if (Using)
        {
            if (int.Parse(TextMoney.text) >= MoneyForLevelUp && counter <= LevelUpCulldown.Length - 1)
            {
                ShowAbilityToLevelUp();
            }
            else
            {
                StopShowAbilityToLevelUp();
            }

            if(Curcooldown >= 0)
                   Curcooldown -= Time.deltaTime;
            if(CanShoot())
                SearchTarget(CabBeatFlingEnemies);
        }
    }


    bool CanShoot()
    {
        if (Curcooldown <= 0)
            return true;
        return false;
    }

    void SearchTarget(bool Can)
    {
        Transform nearestEnemy = null;
        float nearestEnemyDistance = Mathf.Infinity;
        if (Can)
        {
            foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                float currentDistance = Vector2.Distance(transform.position, enemy.transform.position);

                if (currentDistance < nearestEnemyDistance && currentDistance <= Radius)
                {
                    nearestEnemy = enemy.transform;
                    nearestEnemyDistance = currentDistance;
                }
            }
            foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("FlyingEnemy"))
            {
                float currentDistance = Vector2.Distance(transform.position, enemy.transform.position);

                if (currentDistance < nearestEnemyDistance && currentDistance <= Radius)
                {
                    nearestEnemy = enemy.transform;
                    nearestEnemyDistance = currentDistance;
                }
            }
        }
        

        if (nearestEnemy != null)
            Shoot(nearestEnemy);
    }

    void Shoot(Transform enemy)
    {
        Curcooldown = Culldown;


        GameObject obj = Instantiate(Projectile);

        obj.transform.position = transform.position;
        obj.GetComponent<Projcetiletower>().SetTarget(enemy);
    }


}
