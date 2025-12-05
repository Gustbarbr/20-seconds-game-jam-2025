using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed = 5f;
    public float damage;
    public Vector3 direction;

    private void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Shield"))
        {
            PlayerCombat player = other.GetComponentInParent<PlayerCombat>();

            if (player != null)
            {
                float reducedDamage = damage * 0f;

                player.SetHealth(-Mathf.Max(1, reducedDamage)); 
                Destroy(gameObject);
            }
        }
        else if (other.CompareTag("Player"))
        {
            PlayerCombat player = other.GetComponent<PlayerCombat>();

            if (player != null)
            {
                float finalDamage = damage - player.defense;

                player.SetHealth(-Mathf.Max(1, finalDamage));
                Destroy(gameObject);
            }
        }
        else if (!other.isTrigger)
        {
            Destroy(gameObject);
        }
    }
}
