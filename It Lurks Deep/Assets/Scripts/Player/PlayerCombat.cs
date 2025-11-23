using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class PlayerCombat : MonoBehaviour
{
    public PlayerInputActions playerCombat;

    [Header("HP")]
    public float hp;
    public float maxHp;
    [SerializeField]private HealthBarUI healthBarUI;

    [Header("Attack")]
    public float damage;
    private InputAction atk;
    public Animator atkAnimator;

    [Header("Defense")]
    public float defense;
    private InputAction def;
    public Animator defAnimator;

    private void Awake()
    {
        playerCombat = new PlayerInputActions();
    }

    private void OnEnable()
    {
        atk = playerCombat.Player.Attack;
        atk.Enable();
        atk.performed += Attack;

        def = playerCombat.Player.Defend;
        def.Enable();
        def.performed += Defense;
    }

    private void OnDisable()
    {
        atk.Disable();
        def.Disable();
    }

    private void Start()
    {
        healthBarUI.SetMaxHealth(maxHp);
    }

    public void SetHealth(float healthChange)
    {
        hp += healthChange;
        hp = Mathf.Clamp(hp, 0, maxHp);

        healthBarUI.SetHealth(hp);
    }

    void Attack(InputAction.CallbackContext context)
    {
        atkAnimator.SetTrigger("isAttacking");
        SetHealth(-20f);
        Debug.Log("Attack test");
    }

    private void Defense(InputAction.CallbackContext context)
    {
        defAnimator.SetTrigger("isDefending");
        Debug.Log("Defense test");
    }
}
