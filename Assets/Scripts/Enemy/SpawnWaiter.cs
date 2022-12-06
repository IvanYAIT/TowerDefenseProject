using UnityEngine;

public class SpawnWaiter : MonoBehaviour
{
    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= 4)
            Destroy(gameObject);
    }
}
