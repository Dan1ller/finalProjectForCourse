using System.Collections;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Animator Animator;
    [SerializeField] private Transform playerPos;
    [SerializeField] private float speed;
    [SerializeField] private GameObject Attack;
    private bool IsCanAttack = true;
    public bool IsDeath = false;
    private float distance;
    private Vector2 direction;
    private GameObject Player;
    private void Start()
    {
        Animator = GetComponent<Animator>();
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    private void FixedUpdate()
    {
        playerPos = Player.transform;
        distance = Vector2.Distance(transform.position, playerPos.transform.position);
        if (distance <= 1.5f && IsCanAttack)
        {
            IsCanAttack = false;
            StartCoroutine("SpawnAttackPref");
        }
        if (distance < 15f && distance >= 1.4f)
        {
            direction = playerPos.transform.position - transform.position;
            direction = direction.normalized;
            if (direction.x > 0)
            {
                gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
            }
            else
            {
                gameObject.transform.localScale = new Vector3(-1f, 1f, 1f);
            }
            Animator.SetBool("IsRunning", true);
            transform.position = Vector2.MoveTowards(this.transform.position, playerPos.transform.position, speed * Time.deltaTime);
        }
        else
        {
            Animator.SetBool("IsRunning", false);
        }
    }
    private IEnumerator SetIsCanAttackTrue()
    {
        yield return new WaitForSeconds(1f);
        IsCanAttack = true;
    }
    private IEnumerator SpawnAttackPref()
    {
        if (IsDeath)
        {
            yield break;
        }
        yield return new WaitForSeconds(1f);
        Instantiate(Attack, transform.position, Quaternion.identity);
        if (distance >= 1.5f)
        {
            yield return new WaitForSeconds(1f);
            StartCoroutine(SetIsCanAttackTrue());
        }
        else
        {
            yield return new WaitForSeconds(1f);
            StartCoroutine(SpawnAttackPref());
        }
    }

}
