using System.Collections;
using UnityEngine;

public class AttackPrefSpawner : MonoBehaviour
{
    [SerializeField] private int Damage;
    [SerializeField] private string TargetTag;
    [SerializeField] private float LifeTimer;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(TargetTag) && collision.TryGetComponent(out IDamageable Damageable))
        {
            Damageable.ApplyDamage(Damage);
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        StartCoroutine(DestroyObj());
    }
    private IEnumerator DestroyObj()
    {
        yield return new WaitForSeconds(LifeTimer);
        Destroy(gameObject);
    }
}
