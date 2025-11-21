using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{

    public Rigidbody2D rb;

    [Header("Movement")]
    public float moveSpeed;
    float horizontalMovement;
    float verticalMovement;

    [Header("Atk")]
    public float atkDamage;
    public GameObject atkPrefab;
    public InputActionReference atk;

    void Start()
    {
         
    }

    void Update()
    {
        rb.linearVelocity = new Vector2 (horizontalMovement * moveSpeed, verticalMovement * moveSpeed);
    }

    public void PlayerMovement(InputAction.CallbackContext context)
    {
        horizontalMovement = context.ReadValue<Vector2>().x;
        verticalMovement = context.ReadValue<Vector2>().y;
    }

    private void OnEnable()
    {
        atk.action.performed += Attack;
    }

    private void OnDisable()
    {
        atk.action.performed -= Attack;
    }

    private void Attack(InputAction.CallbackContext context)
    {
        GameObject atkObject = Instantiate(atkPrefab, transform.position, Quaternion.identity);
        StartCoroutine(AttackFadeInFadeOut(atkObject));
    }

    IEnumerator AttackFadeInFadeOut(GameObject atkObject)
    {
        float fadeIn = 0f;
        float fadeOut = 0.5f;
        float atkPosition = 0f;

        while(fadeIn <= fadeOut)
        {
            fadeIn += Time.deltaTime;
            atkPosition += Time.deltaTime * 5;
            atkObject.transform.position = new Vector2(transform.position.x, transform.position.y + atkPosition);
            yield return null;
        }

        Destroy(atkObject);
    }
}
