using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    [Header("Status")]
    public float hp;
    public float damage;
    public float defense;
    private bool isAttacking = false;

    [Header("Reeferences")]
    public PlayerCombat player;
    public BoonsControl boon;
    public SpawnEnemy spawnEnemy;
    public GameObject fireballPrefab;
    public Transform fireballSpawnPos;
    public ScoreControl scoreControl;

    [Header("HitColor")]
    private SpriteRenderer sprite;
    private Color originalColor;
    private bool isFlashing = false;


    private void Start()
    {
        player = FindAnyObjectByType<PlayerCombat>();
        boon = FindAnyObjectByType<BoonsControl>();
        spawnEnemy = FindAnyObjectByType<SpawnEnemy>();
        scoreControl = FindAnyObjectByType<ScoreControl>();

        sprite = GetComponentInChildren<SpriteRenderer>();
        originalColor = sprite.color;
    }

    void Update()
    {
        if (hp <= 0)
        {
            spawnEnemy.Spawn();
            boon.ChosenBoon();
            scoreControl.score += 100;
            Destroy(gameObject);
        }

        FireballAttack();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Sword")
        {
            float finalDamage = player.damage;

            if (player.isCrit)
                finalDamage *= (1f + player.critDamage);

            hp -= finalDamage - defense;

            StartCoroutine(FlashRed());
        }

        IEnumerator FlashRed()
        {
            if (isFlashing) yield break;
            isFlashing = true;

            sprite.color = Color.red;
            yield return new WaitForSeconds(0.1f);
            sprite.color = originalColor;

            isFlashing = false;
        }

    }


    public void FireballAttack()
    {
        if (isAttacking) return; 

        if (Vector3.Distance(transform.position, player.transform.position) < 5f)
        {
            StartCoroutine(FireballRoutine());
        }
    }


    IEnumerator FireballRoutine()
    {
        isAttacking = true;

        yield return new WaitForSeconds(1.2f);

        GameObject fireballObj = Instantiate(
            fireballPrefab,
            fireballSpawnPos.position,
            Quaternion.identity
        );

        Fireball fireball = fireballObj.GetComponent<Fireball>();
        fireball.damage = damage;
        fireball.direction = (player.transform.position - fireballSpawnPos.position).normalized;

        yield return new WaitForSeconds(2f); 

        isAttacking = false;
    }

}
