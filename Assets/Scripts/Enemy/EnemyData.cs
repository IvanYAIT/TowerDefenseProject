using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "SO/NewEnemyData")]
public class EnemyData : ScriptableObject
{
    [SerializeField] private int hp;
    [SerializeField] private float speed;
    [SerializeField] private bool isFlying;
    [SerializeField] private int damageToTower;
    [SerializeField] private int moneyPerDeath;
    [SerializeField] private EnemyType enemyType;

    public int Hp => hp;
    public int MoneyPerDeath => moneyPerDeath;
    public float Speed => speed;
    public bool IsFlying => isFlying;
    public int DamageToTower => damageToTower;
    public EnemyType EnemyType => enemyType;
}


public enum EnemyType
{
    Normal,
    Flying,
    Heavy
}