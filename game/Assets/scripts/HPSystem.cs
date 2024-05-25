using System.Collections;
using UnityEngine;

public class HPSystem : MonoBehaviour, IDamageable
{
    [SerializeField] private int MaxHP = 100;
    [SerializeField] private int currentHP;
    private Animator animator;
    private EnemyMovement MoveClass;
    private slimeMovement moveClass;
    private EnemyShooting enemyShooting;
    private HPSystem hpSystem;
    private Collider2D Col;
    private bool CanDamage = true;
    public bool IsDeath = false;
    public bool isZombie = false;
    private AddRoom Room;
    private void Start()
    {
        if (isZombie)
        {
            MoveClass = GetComponent<EnemyMovement>();
        }
        else
        {
            moveClass = GetComponent<slimeMovement>();
            enemyShooting = GetComponent<EnemyShooting>();
        }

        currentHP = MaxHP;
        animator = GetComponent<Animator>();
        hpSystem = GetComponent<HPSystem>();
        Col = GetComponent<Collider2D>();
        Room = GetComponentInParent<AddRoom>();
    }
    public void ApplyDamage(int DamageValue)
    {
        if (CanDamage)
        {
            currentHP -= DamageValue;
            if (isZombie)
            {
                animator.SetBool("IsApplyDamage", true);
                StartCoroutine(SetAnimFalse());
            }
            if (currentHP <= 0)
            {
                if (!isZombie)
                {
                    enemyShooting.enabled = false;
                    Room.enemies.Remove(gameObject);
                    IsDeath = true;
                    moveClass.IsDeath = true;
                    moveClass.enabled = false;
                    Destroy(gameObject);
                }
                else
                {
                    Room.enemies.Remove(gameObject);
                    animator.SetBool("IsDeath", true);
                    IsDeath = true;
                    StartCoroutine("Death");
                    MoveClass.IsDeath = true;
                    MoveClass.enabled = false;
                    StopCoroutine("SpawnAttackPref");
                    hpSystem.enabled = false;
                    Col.enabled = false;
                }
            }
        }
    }
    public void Heal()
    {
        currentHP += 20;
        if (currentHP > 100)
        { 
            currentHP = 100;
        }
    }
    public void Immortality()
    {
        CanDamage = false;
        StartCoroutine("SetCanDamageTrue");
    }    
    private IEnumerator SetAnimFalse()
    {
        yield return new WaitForSeconds(0.2f);
        animator.SetBool("IsApplyDamage", false);
    }
    private IEnumerator SetCanDamageTrue()
    {
        yield return new WaitForSeconds(4f);
        CanDamage = true;
    }

}
