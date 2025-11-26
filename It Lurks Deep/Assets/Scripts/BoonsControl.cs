using System.Collections.Generic;
using TMPro;
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
    public TextMeshProUGUI boonObtainedText;

    [Header("Timer")]
    public bool setTimer = false;
    public float actualTime = 0;
    public float finishTime = 2f;

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

        if(setTimer == true)
        {
            actualTime += Time.deltaTime;
            if(actualTime >= finishTime)
            {
                boonObtainedText.enabled = false;
                actualTime = 0f;
                setTimer = false;
            }
        }
    }

    public void ChosenBoon()
    {
        if (boonsList.Count == 0) return;

        boonObtainedText.enabled = true;

        int randomIndex = Random.Range(0, boonsList.Count);
        BoonType boon = boonsList[randomIndex];

        switch (boon)
        {
            case BoonType.AtkUp:
                playerCombat.damage += 5f;
                boonObtainedText.text = "Obtained a new boon: Attack Up";
                break;
            case BoonType.AtkDown:
                enemyControl.damage -= 5f;
                boonObtainedText.text = "Obtained a new boon: Enemy Attack Down";
                break;
            case BoonType.DefUp:
                playerCombat.defense += 1.5f;
                boonObtainedText.text = "Obtained a new boon: defense Up";
                break;
            case BoonType.DefDown:
                enemyControl.defense -= 2.5f;
                boonObtainedText.text = "Obtained a new boon: Enemy Defense Down";
                break;
            case BoonType.CritRateUp:
                playerCombat.critRate += 0.25f; // 25% crit rate
                boonObtainedText.text = "Obtained a new boon: Crit Rate Up";
                break;
            case BoonType.CritDmgUp:
                playerCombat.critDamage += 0.3f; // 30% crit damage
                boonObtainedText.text = "Obtained a new boon: Crit Damage Up";
                break;
        }

        setTimer = true;
    }
}
