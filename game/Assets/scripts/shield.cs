using UnityEngine;

public class shield : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<HPSystem>().Immortality();
            Destroy(gameObject);
        }
    }
}
