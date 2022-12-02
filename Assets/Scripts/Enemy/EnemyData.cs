using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "SO/NewEnemyData")]
public class EnemyData : ScriptableObject
{
    [SerializeField] private int hp;
    [SerializeField] private float speed;
    [SerializeField] private bool isFlying;
    [SerializeField] private int damageToTower;

    public int Hp => hp;
    public float Speed => speed;
    public bool IsFlying => isFlying;
    public int DamageToTower => damageToTower;
}
