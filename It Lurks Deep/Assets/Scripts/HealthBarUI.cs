using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    public float hp, maxHp, width, heigth;
    [SerializeField] private RectTransform healthBar;

    public void SetMaxHealth(float maxHealth)
    {
        maxHp = maxHealth;
    }

    public void SetHealth(float health)
    {
        hp = health;
        float newWidth = (hp/maxHp) * width;
        healthBar.sizeDelta = new Vector2(newWidth, heigth);
    }
}
