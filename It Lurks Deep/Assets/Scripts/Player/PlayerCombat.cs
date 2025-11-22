using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCombat : MonoBehaviour
{
    public PlayerInputActions playerCombat;
    public Animator animator;

    [Header("Attack")]
    public float damage;
    private InputAction atk;

    [Header("Defense")]
    public float defense;
    private InputAction def;

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

    void Update()
    {

    }

    void Attack(InputAction.CallbackContext context)
    {
        animator.SetTrigger("isAttacking");
        Debug.Log("Attack test");
    }

    private void Defense(InputAction.CallbackContext context)
    {
        Debug.Log("Defense test");
    }
}
