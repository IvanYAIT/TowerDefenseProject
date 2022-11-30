using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "SO/NewEnemyData")]
public class EnemyData : ScriptableObject
{
    [SerializeField] private int hp;
    [SerializeField] private float speed;
    [SerializeField] private bool isFlying;

    public int Hp => hp;
    public float Speed => speed;
    public bool IsFlying => isFlying;
}
