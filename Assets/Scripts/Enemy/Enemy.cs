using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyData enemyData;

    private float speed;
    private int directionLR;
    private int directionUD;
    private bool isFlying;

    void Start()
    {
        speed = enemyData.Speed;
        isFlying = enemyData.IsFlying;
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
        if (other.CompareTag("Left"))
            transform.rotation = new Quaternion(0, -90, 0, 90);
        else if (other.CompareTag("Right"))
            transform.rotation = new Quaternion(0, 90, 0, 90);
        else if (other.CompareTag("Up"))
            transform.rotation = new Quaternion(0, 0, 0, 0);
        else if (other.CompareTag("Down"))
            transform.rotation = new Quaternion(0, 180, 0, 0);
        else if (other.CompareTag("RandomLeft"))
            if (Random.Range(1, 3) == 1)
                transform.rotation = new Quaternion(0, -90, 0, 90);
        else if (other.CompareTag("RandomRight"))
            if (Random.Range(1, 3) == 1)
                transform.rotation = new Quaternion(0, 90, 0, 90);
       else if (other.CompareTag("RandomUp"))
            if (Random.Range(1, 3) == 1)
                transform.rotation = new Quaternion(0, 0, 0, 0);
        else if (other.CompareTag("RandomDown"))
            if (Random.Range(1, 3) == 1)
                transform.rotation = new Quaternion(0, 180, 0, 0);
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
        if (other.CompareTag("Finish"))
        {
            Destroy(gameObject);
        }
    }
}
