using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankBossDefault : MonoBehaviour
{
    public Transform playerTransform;
    public GameObject shockWave;
    public float moveSpeed = 7f;
    public float xLimit = 25f;
    public bool canAttack = true;
    public bool moveLeft = true;

    private Rigidbody2D rb;

    float distance;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (moveLeft)
        {
            rb.velocity = new Vector2(5f, 0);
            if (transform.position.x >= xLimit)
            {
                moveLeft = !moveLeft;
            }
        }
        else
        {
            rb.velocity = new Vector2(-5f, 0);
            if (transform.position.x <= -xLimit)
            {
                moveLeft = !moveLeft;
            }
        }
        distance = Vector3.Distance(playerTransform.position, transform.position);
        if (distance <= 3f && canAttack)
        {
            canAttack = false;
            GameObject attackCircle = Instantiate(shockWave, transform.position + new Vector3(2f, 8f, 0), Quaternion.identity);
            attackCircle.transform.position = transform.position;
            Destroy(attackCircle, 3f);
            StartCoroutine(setAttack());
        }

    }

    IEnumerator setAttack()
    {
        yield return new WaitForSeconds(10f);
        canAttack = true;
    }
}
