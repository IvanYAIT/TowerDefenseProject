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
    private Text TextMoney;
    private int counter = 0;
    [SerializeField] private int CountOfUpgrades = 2;
    [SerializeField] private GameObject[] TowerPrefabs;
    [SerializeField] public bool Using;
    [SerializeField] int lvlofTower = 0;
    [SerializeField] private GameObject Projectile;
    [SerializeField] private bool CabBeatFlingEnemies;
    [SerializeField] private bool typeThree;
    private GameObject objUpgrade = null;
    private int IndexOfCheckPrefab;

    public void SetTextMoney(Text TextMoney) => this.TextMoney = TextMoney;

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
        ResourceManager.Instance.money -= MoneyForLevelUp;
        SetNewTower();
    }

    private void SetNewTower()
    {
        if (lvlofTower > CountOfUpgrades)
        {

        }
        else
        {
            GameObject obj = Instantiate(TowerPrefabs[lvlofTower], transform.position, transform.rotation);
            obj.GetComponent<Tower>().lvlofTower = this.lvlofTower + 1;
            Destroy(this.gameObject);
        }
    }


    private void Update()
    {
        if (Using)
        {
            if (Curcooldown >= 0)
                Curcooldown -= Time.deltaTime;
            if (CanShoot())
                SearchTarget(CabBeatFlingEnemies);
        }


        if (ResourceManager.Instance.money >= MoneyForLevelUp && objUpgrade == null && lvlofTower < CountOfUpgrades)
        {
            objUpgrade = Instantiate(ShownObject, new Vector3(transform.position.x, 8.2f, transform.position.z), ShownObject.transform.rotation);
            objUpgrade.GetComponent<scheking>().index = IndexManager.SetIndex();
            IndexOfCheckPrefab = objUpgrade.GetComponent<scheking>().index;

        }
        else if ((ResourceManager.Instance.money < MoneyForLevelUp && objUpgrade != null) || lvlofTower >= CountOfUpgrades)
        {
            Destroy(objUpgrade);
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.tag == "Upgrade" && hit.transform.GetComponent<scheking>().index == IndexOfCheckPrefab)
                {
                    LevelUp();
                    Destroy(objUpgrade);
                }
            }
        }
    }


    bool CanShoot()
    {
        if (Curcooldown <= 0)
            return true;
        return false;
    }

    void CheckTarget(List<GameObject> enemies, string tag, out Transform currentEnemy)
    {
        float nearestEnemyDistance = Mathf.Infinity;
        int enemyIndexWithMaxLifetime=0;
        float maxlifetime=0;
        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag(tag))
        {
            float currentDistance = Vector3.Distance(transform.position, enemy.transform.position);

            if (currentDistance < nearestEnemyDistance && currentDistance <= Radius)
            {
                enemies.Add(enemy);
            }
        }

        for (int i = 0; i < enemies.Count; i++)
        {
            if(enemies[i].GetComponent<Enemy>().LifeTime > maxlifetime)
            {
                maxlifetime = enemies[i].GetComponent<Enemy>().LifeTime;
                enemyIndexWithMaxLifetime = i;
            }
        }
        if (enemies.Count >= 1)
            currentEnemy = enemies[enemyIndexWithMaxLifetime].transform;
        else
            currentEnemy = null;
    }

    void SearchTarget(bool Can)
    {
        Transform nearestEnemy = null;
        Transform nearestFlyingEnemy = null;
        Transform[] arr = new Transform[2];
        float nearestEnemyDistance = Mathf.Infinity;
        List<GameObject> enemiesInRadius = new List<GameObject>();
        if (Can)
        {
            CheckTarget(enemiesInRadius, "FlyingEnemy", out nearestEnemy);
        }
        else if (typeThree)
        {
            CheckTarget(enemiesInRadius, "FlyingEnemy", out nearestFlyingEnemy);
            CheckTarget(enemiesInRadius, "Enemy", out nearestEnemy);
            arr[0] = nearestEnemy;
            arr[1] = nearestFlyingEnemy;
            foreach (Transform enemy in arr)
                Shoot(enemy);
        }
        else
        {
            CheckTarget(enemiesInRadius, "Enemy", out nearestEnemy);
        }


        if (nearestEnemy != null && !typeThree)
            Shoot(nearestEnemy);
    }

    void Shoot(Transform enemy)
    {
        Curcooldown = Culldown;

        GameObject obj = Instantiate(Projectile);
        Projcetiletower projcetiletower = obj.GetComponent<Projcetiletower>();

        projcetiletower.SetDamage(Power);
        obj.transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
        projcetiletower.SetTarget(enemy);
    }
}