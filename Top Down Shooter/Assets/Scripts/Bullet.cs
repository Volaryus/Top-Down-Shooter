using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public GameObject hitEffect;
    public float damage = 5f;
    private void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        if(collision.CompareTag("Player")||collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(damage);
        }
        Destroy(effect, 0.2f);
        Destroy(gameObject);
    }

    public void shotForce(Transform firePoint,float bulletForce)
    {
        GetComponent<Rigidbody2D>().AddForce(firePoint.up * bulletForce,ForceMode2D.Impulse);
    }
}
