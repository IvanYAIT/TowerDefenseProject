using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projcetiletower : MonoBehaviour
{
    [SerializeField] private float speed = 7;

    private int damage;
    private Transform target;

    public void SetDamage(int damage) => this.damage = damage;

    void Update()
    {
        Move();
    }

    public void SetTarget(Transform enemy)
    {
        target = enemy;
    }

    private void Move()
    {
        if(target != null)
        {
            if(Vector3.Distance(transform.position, target.position) < .1f)
            {
                Destroy(gameObject);
                target.GetComponent<Enemy>().GetDamage(damage);
            }
            else
            {
                Vector3 dir = target.position - transform.position;

                transform.Translate(dir.normalized * Time.deltaTime * speed);
            }
        }
        else
            Destroy(gameObject);
    }
}
