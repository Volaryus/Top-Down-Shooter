using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public Transform playerTransform;
    public Transform firePoint;
    public Transform tankPosition;
    public GameObject bullet;
    public float shootForce;
    Rigidbody2D rb;
    float timer = 0;
    public float shootFrequency = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = tankPosition.position+new Vector3(1.19f,6.3f,0);
        Vector3 direction = playerTransform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg-90;
        rb.rotation = angle;
        timer += Time.deltaTime;
        if(timer>=shootFrequency)
        {
            timer = 0f;
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject shotBullet = Instantiate(bullet, firePoint.position, firePoint.rotation);
        shotBullet.GetComponent<Bullet>().shotForce(firePoint, shootForce);
    }
}
