using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public float hp;
    public float damage;
    public float defense;
    public PlayerCombat player;
    public BoonsControl boon;
    public SpawnEnemy spawnEnemy;

    private void Start()
    {
        player = FindAnyObjectByType<PlayerCombat>();
        boon = FindAnyObjectByType<BoonsControl>();
        spawnEnemy = FindAnyObjectByType<SpawnEnemy>();
    }

    void Update()
    {
        if (hp <= 0)
        {
            spawnEnemy.Spawn();
            boon.ChosenBoon();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Sword")
        {
            float finalDamage = player.damage;

            if (player.isCrit)
                finalDamage *= (1f + player.critDamage);

            hp -= finalDamage - defense;
        }
    }
}
