using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverZombie : MonoBehaviour
{
    private SpriteRenderer sr;
    private Rigidbody2D rb;
    private Animator animator;

    private bool valor = false;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr.flipX = true;
        valor = false;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(1, rb.velocity.y);
        sr.flipX = false;
        if (valor == true)
        {
            animator.SetInteger("Zombie", 1);
            Destroy(this.gameObject, 1);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Kunai")
        {
            valor = true;
            Debug.Log("Chocaste con un Kunai");
        }
    }
}
