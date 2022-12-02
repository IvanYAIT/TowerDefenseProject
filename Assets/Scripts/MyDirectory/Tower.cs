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
    private Text TextMoney;
    private int counter = 0;
    [SerializeField] private float[] LevelUpCulldown;
    [SerializeField] private int[] LevelupPower;
    [SerializeField] private int[] LevelUpRadius;
    [SerializeField] private int[] NeededMoneyForLevelUp;
    [SerializeField] public bool Using;
    [SerializeField] private GameObject Projectile;
    [SerializeField] private bool CabBeatFlingEnemies;
    [SerializeField] private bool typeThree;
    private GameObject objUpgrade = null;

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
        Power += LevelupPower[counter];
        Radius += LevelUpRadius[counter];
        Culldown -= LevelUpCulldown[counter];
        MoneyForLevelUp += NeededMoneyForLevelUp[counter];
        ResourceManager.Instance.money -= MoneyForLevelUp;
        counter++;
    }


    private void Update()
    {
        if (Using)
        {


            if(Curcooldown >= 0)
                   Curcooldown -= Time.deltaTime;
            if(CanShoot())
                SearchTarget(CabBeatFlingEnemies);
        }

        
        if(ResourceManager.Instance.money >= MoneyForLevelUp && objUpgrade == null && counter !=2)
        {
            objUpgrade = Instantiate(ShownObject, new Vector3(transform.position.x, transform.position.y + 2, transform.position.z), transform.rotation);
        } else if (ResourceManager.Instance.money <= MoneyForLevelUp && objUpgrade == null)
        {
            Destroy(objUpgrade);
        }

        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.tag == "Upgrade")
                {
                    Debug.Log(hit);
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


    void SearchTarget(bool Can)
    {
        Transform nearestEnemy = null;
        Transform nearestFlyingEnemy = null;
        float nearestEnemyDistance = Mathf.Infinity;
        if (Can)
        {

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
        else if (typeThree)
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
            Shoot(nearestEnemy);
            foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("FlyingEnemy"))
            {
                float currentDistance = Vector2.Distance(transform.position, enemy.transform.position);

                if (currentDistance < nearestEnemyDistance && currentDistance <= Radius)
                {
                    nearestFlyingEnemy = enemy.transform;
                    nearestEnemyDistance = currentDistance;
                }
            }
            Shoot(nearestFlyingEnemy);
        }
        else
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
        }
        

        if (nearestEnemy != null)
            Shoot(nearestEnemy);
    }

    void Shoot(Transform enemy)
    {
        Curcooldown = Culldown;

        GameObject obj = Instantiate(Projectile);
        Projcetiletower projcetiletower = obj.GetComponent<Projcetiletower>();

        projcetiletower.SetDamage(Power);
        obj.transform.position = new Vector3(transform.position.x, transform.position.y+1, transform.position.z);
        projcetiletower.SetTarget(enemy);
    }
}
