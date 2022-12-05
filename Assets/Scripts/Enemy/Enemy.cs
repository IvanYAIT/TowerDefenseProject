using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour, IDamagable
{
    [SerializeField] private EnemyData enemyData;

    private float speed;
    private int directionLR;
    private int directionUD;
    private bool isFlying;
    private int damageToTower;
    private int currentHp;
    private Slider progressBar;

    public void SetProgressBar(Slider progressBar) => this.progressBar = progressBar;

    void Start()
    {
        speed = enemyData.Speed;
        isFlying = enemyData.IsFlying;
        damageToTower = enemyData.DamageToTower;
        currentHp = enemyData.Hp;
        directionLR = 1;
        directionUD = 0;
    }

    public EnemyType GetEnemyType()
    {
        return enemyData.EnemyType;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Update()
    {
        if (currentHp <= 0)
        {
            Death();
            ResourceManager.Instance.money += enemyData.MoneyPerDeath;
        }
    }

    private void Move()
    {
        transform.Translate(new Vector3(1,0, 0) * speed * Time.fixedDeltaTime);
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Turn"))
            transform.eulerAngles = other.transform.rotation.eulerAngles;
        else if (other.CompareTag("RandomLeft"))
            if (Random.Range(1, 3) == 1)
                transform.eulerAngles = other.transform.rotation.eulerAngles;


        if (other.CompareTag("Tower"))
        {
            Death();
            other.gameObject.GetComponent<MainTower>().GetDamage(damageToTower);
        }
    }

    public void GetDamage(int damage)=>
        currentHp -= damage;

    public void Death()
    {
        Destroy(gameObject);
        progressBar.value++;
    }
}