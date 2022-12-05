using UnityEngine;

public class SpawnWaiter : MonoBehaviour
{
    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= 5)
            Destroy(gameObject);
    }
}
