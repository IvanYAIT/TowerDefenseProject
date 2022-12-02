using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamagable
{
    [SerializeField] private EnemyData enemyData;

    private float speed;
    private int directionLR;
    private int directionUD;
    private bool isFlying;
    private int damageToTower;
    private int currentHp;

    void Start()
    {
        speed = enemyData.Speed;
        isFlying = enemyData.IsFlying;
        damageToTower = enemyData.DamageToTower;
        currentHp = enemyData.Hp;
        directionLR = 1;
        directionUD = 0;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(new Vector3(1,0, 0) * speed * Time.fixedDeltaTime);
    }



    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("RandomLeft") && !other.CompareTag("Enemy"))
            transform.eulerAngles = other.transform.rotation.eulerAngles;
        else if (other.CompareTag("RandomLeft") && !other.CompareTag("Enemy"))
            if (Random.Range(1, 3) == 1)
                transform.eulerAngles = other.transform.rotation.eulerAngles;










        if (other.CompareTag("Bullet") && !isFlying)
        {
            Destroy(gameObject);
            ResourceManager.Instance.money += 100;
        }
        if (other.CompareTag("BulletFromFlyingEnemy") && isFlying)
        {
            Destroy(gameObject);
            ResourceManager.Instance.money += 100;
        }


        if (other.CompareTag("Tower"))
        {
            Destroy(gameObject);
            other.gameObject.GetComponent<MainTower>().GetDamage(damageToTower);
        }
    }

    public void GetDamage(int damage)=>
        currentHp -= damage;
}
