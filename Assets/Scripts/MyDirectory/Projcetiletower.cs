using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projcetiletower : MonoBehaviour
{
    [SerializeField] private float speed = 7;
    private Transform target;
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
            if(Vector2.Distance(transform.position, target.position) < .1f)
                Destroy(gameObject);
            else
            {
                Vector2 dir = target.position - transform.position;

                transform.Translate(dir.normalized * Time.deltaTime * speed);
            }
        }
        else
            Destroy(gameObject);
    }
}
