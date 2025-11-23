using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public float hp;
    public float damage;
    public float defense;
    public PlayerCombat player;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Sword")
        {
            hp -= player.damage;
        }
    }
}
