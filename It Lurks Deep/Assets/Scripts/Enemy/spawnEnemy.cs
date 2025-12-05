using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public List<GameObject> enemiesPrefabs = new List<GameObject>();
    public Transform player;                   
    public float distanceInFront = 5f;       

    public void Spawn()
    {
        if (enemiesPrefabs.Count == 0)
            return;

        int randomIndex = Random.Range(0, enemiesPrefabs.Count);
        GameObject selectedEnemy = enemiesPrefabs[randomIndex];

        Vector3 spawnPos = player.position + player.forward * distanceInFront;
        spawnPos.y = 2f;

        GameObject enemy = Instantiate(selectedEnemy, spawnPos, Quaternion.identity);

        enemy.GetComponent<EnemyControl>().spawnEnemy = this;
    }
}
