using UnityEngine;

public class door : MonoBehaviour
{
    public GameObject block;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("block"))
        {
            Instantiate(block, transform.GetChild(0).position, Quaternion.identity);
            Instantiate(block, transform.GetChild(1).position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
