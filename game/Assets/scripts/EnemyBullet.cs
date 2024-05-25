using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private GameObject Player;
    private Rigidbody2D rb;
    [SerializeField] float force;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();

        Vector3 direction = Player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
    }

    void Update()
    {

    }
}
