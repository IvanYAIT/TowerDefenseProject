using UnityEngine;

public class SpawnWaiter : MonoBehaviour
{
    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        transform.Rotate(new Vector3(0, 0, 1), 0.5f);
        if(timer >= 4)
            Destroy(gameObject);
    }
}
