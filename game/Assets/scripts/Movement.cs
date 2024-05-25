using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 movementDir;
    [SerializeField] private int Movespeed;
    private Animator animator;

    public void OnMove(InputAction.CallbackContext context)
    {
        movementDir = context.ReadValue<Vector2>();
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        if (movementDir.x != 0 || movementDir.y != 0)
        {
            animator.SetBool("IsRunning", true);
        }
        else
        {
            animator.SetBool("IsRunning", false);
        }

    }
    private void FixedUpdate()
    {
        rb.velocity = movementDir * Movespeed;
    }


}
