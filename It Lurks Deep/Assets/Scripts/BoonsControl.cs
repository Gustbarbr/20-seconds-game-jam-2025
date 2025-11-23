using System.Collections.Generic;
using UnityEngine;

public enum BoonType
{
    AtkUp,
    AtkDown,
    DefUp,
    DefDown,
    CritRateUp,
    CritDmgUp
}

public class BoonsControl : MonoBehaviour
{
    private List<BoonType> boonsList = new List<BoonType>();

    public PlayerCombat playerCombat;
    public EnemyControl enemyControl;

    private void Start()
    {
        boonsList.Add(BoonType.AtkUp);
        boonsList.Add(BoonType.AtkDown);
        boonsList.Add(BoonType.DefUp);
        boonsList.Add(BoonType.DefDown);
        boonsList.Add(BoonType.CritRateUp);
        boonsList.Add(BoonType.CritDmgUp);
    }

    private void Update()
    {
        if (enemyControl.damage <= 0f)
            boonsList.Remove(BoonType.AtkDown);
        if (enemyControl.defense <= 0f)
            boonsList.Remove(BoonType.DefDown);
    }

    public void ChosenBoon()
    {
        if (boonsList.Count == 0) return;

        int randomIndex = Random.Range(0, boonsList.Count);
        BoonType boon = boonsList[randomIndex];

        switch (boon)
        {
            case BoonType.AtkUp:
                playerCombat.damage += 5f;
                break;
            case BoonType.AtkDown:
                enemyControl.damage -= 5f;
                break;
            case BoonType.DefUp:
                playerCombat.defense += 1.5f;
                break;
            case BoonType.DefDown:
                enemyControl.defense -= 2.5f;
                break;
            case BoonType.CritRateUp:
                playerCombat.critRate += 0.25f; // 25% crit rate
                break;
            case BoonType.CritDmgUp:
                playerCombat.critDamage += 0.3f; // 30% crit damage
                break;
        }
    }
}
