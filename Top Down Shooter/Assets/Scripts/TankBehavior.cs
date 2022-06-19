using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TankBehavior : MonoBehaviour
{
    Health health;
    public GameObject explosionEffect;
    public GameObject empEffect;
    public GameObject player;
    public Turret turret;
    public bool faze1 = false;
    public bool faze2 = false;
    public bool canChange = true;
    public bool canChange2 = true;
    public Slider healthSlider;
    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<Health>();

    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = health.health;
        if (health.health <= 300 && canChange)
        {
            faze1 = true;
        }
        if (faze1)
        {
            StartCoroutine(Faze1());
        }
        if (health.health <= 100 && canChange2)
        {
            faze2 = true;

        }
        if (faze2)
        {
            StartCoroutine(Faze2());
        }
    }

    IEnumerator Faze1()
    {
        canChange = false;
        faze1 = false;
        for (int i = 0; i < 10; i++)
        {
            float xPos = i % 2 == 0 ? Random.Range(-15f, -5f) : Random.Range(5f, 15f);
            float yPos = Random.Range(-15f, 15f);
            GameObject bomb = Instantiate(explosionEffect, new Vector2(xPos, yPos), Quaternion.identity);
            Destroy(bomb, 3f);
            StartCoroutine(CloseSprite(bomb));
        }

        yield return new WaitForSeconds(5f);
        faze1 = true;

    }

    IEnumerator Faze2()
    {
        faze2 = false;
        health.canTakeDamage = true;
        canChange2 = false;
        GameObject activeEmp = Instantiate(empEffect, transform.position, Quaternion.identity);
        Destroy(activeEmp, 2f);
        player.GetComponent<Gun>().enabled = false;
        yield return new WaitForSeconds(3f);
        health.canTakeDamage = false;
        player.GetComponent<Gun>().enabled = true;
        yield return new WaitForSeconds(5f);
        health.canTakeDamage = true;
        yield return new WaitForSeconds(5f);
        faze2 = true;
    }





    IEnumerator CloseSprite(GameObject spriteToClose)
    {
        yield return new WaitForSeconds(1f);
        spriteToClose.GetComponent<Animator>().enabled = false;
        spriteToClose.GetComponent<SpriteRenderer>().enabled = false;
        spriteToClose.transform.GetChild(0).gameObject.SetActive(true);
        Destroy(spriteToClose, 0.6f);
    }
}
