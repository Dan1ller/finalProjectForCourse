using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slimeMovement : MonoBehaviour
{
    private float distance;
    private GameObject Player;
    private Vector2 direction;
    [SerializeField] private float speed;
    public bool IsDeath = false;
    private bool KD = false;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!IsDeath && !KD)
        {
            distance = Vector2.Distance(transform.position, Player.transform.position);
            if (distance <= 2f && !KD)
            {
                direction = Player.transform.position - transform.position;
                direction = direction.normalized;
                if (direction.x > 0)
                {
                    gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
                }
                else
                {
                    gameObject.transform.localScale = new Vector3(-1f, 1f, 1f);
                }
                transform.Translate(-direction * 50f * Time.deltaTime);
                StartCoroutine("KDC");
            }
        }
    }
    public IEnumerator KDC()
    {
        KD = true;
        yield return new WaitForSeconds(5f);
        KD = false;
    }

}
