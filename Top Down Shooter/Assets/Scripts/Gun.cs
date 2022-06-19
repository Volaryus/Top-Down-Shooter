using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bullet;
    public float shootForce = 20f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        
        GameObject shotBullet = Instantiate(bullet, firePoint.position, firePoint.rotation);
        shotBullet.GetComponent<Bullet>().shotForce(firePoint, shootForce);
        //shotBullet.transform.localRotation = Quaternion.Euler(0, 0, firePoint.rotation.z+45);
       /* Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(1,1) * shootForce, ForceMode2D.Impulse);*/
       // bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * shootForce, ForceMode2D.Impulse);
    }
}
