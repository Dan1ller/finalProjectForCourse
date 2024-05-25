using System.Collections;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private Animator animator;
    private bool IsCanAttack = true;
    [SerializeField] private int damageValue;
    [SerializeField] private Camera cam;
    [SerializeField] private Vector3 mousePoint;
    [SerializeField] private GameObject Holder;
    [SerializeField] private GameObject Player;
    [SerializeField] private Transform AttackSpawner;
    [SerializeField] private GameObject AttackPref;
    private bool IsAttacking;

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        IsAttacking = Input.GetButtonDown("Fire1");

        mousePoint = cam.ScreenToWorldPoint(Input.mousePosition);
        Holder.transform.rotation = Quaternion.Euler(Holder.transform.rotation.eulerAngles.x, Holder.transform.rotation.eulerAngles.y, Mathf.Atan2(mousePoint.y - Holder.transform.position.y, mousePoint.x - Holder.transform.position.x) * Mathf.Rad2Deg - 90);
        if (transform.position.x > mousePoint.x)
        {
            Player.transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (transform.position.x < mousePoint.x)
        {
            Player.transform.localScale = new Vector3(1, 1, 1);
        }
        if (IsAttacking && IsCanAttack)
        {
            IsCanAttack = false;
            Instantiate(AttackPref, AttackSpawner);
            animator.SetBool("attack", true);
            StartCoroutine(SetFalseAttack());
        }
    }
    private IEnumerator SetFalseAttack()
    {
        yield return new WaitForSeconds(0.25f);
        animator.SetBool("attack", false);
        IsCanAttack = true;
    }
}
