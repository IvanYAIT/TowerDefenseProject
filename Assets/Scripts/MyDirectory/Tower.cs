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
        SetNewTower();
    }

    private void SetNewTower()
    {
        if (lvlofTower <= CountOfUpgrades)
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


        if (ResourceManager.Instance.money >= MoneyForLevelUp && objUpgrade == null && lvlofTower <= CountOfUpgrades)
        {
            objUpgrade = Instantiate(ShownObject, new Vector3(transform.position.x, transform.position.y + 2, transform.position.z), transform.rotation);
            objUpgrade.GetComponent<scheking>().index = IndexManager.SetIndex();
            IndexOfCheckPrefab = objUpgrade.GetComponent<scheking>().index;

        }
        else if ((ResourceManager.Instance.money <= MoneyForLevelUp && objUpgrade == null) || lvlofTower <= CountOfUpgrades)
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
        obj.transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
        projcetiletower.SetTarget(enemy);
    }
}