using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlarPersonaje : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer sr;
    private Transform _transform;

    private int numSaltos = 0;
    private float tiempo = 0;

    private bool escalera = false;
    private bool estaEnSuelo = false;
    public Text textoPuntaje;

    public GameObject Kunai;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        _transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!escalera)
        {
            rb.gravityScale = 10;
            rb.velocity = new Vector2(0, rb.velocity.y);
            animator.SetInteger("Cambio", 0);
        }

        if (rb.gravityScale == 0)
        {
            rb.velocity = new Vector2(0, 0);
            animator.SetInteger("Cambio", 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            sr.flipX = false;
            rb.velocity = new Vector2(3, rb.velocity.y);
            animator.SetInteger("Cambio", 1);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            sr.flipX = true;
            rb.velocity = new Vector2(-3, rb.velocity.y);
            animator.SetInteger("Cambio", 1);
        }
        if (Input.GetKeyUp(KeyCode.Space) && numSaltos < 1)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(new Vector2(0, 25), ForceMode2D.Impulse);
            numSaltos++;
        }
        if (escalera)
        {
            animator.SetInteger("Cambio", 0);
            rb.velocity = new Vector2(rb.velocity.x, 0);

            if (Input.GetKey(KeyCode.UpArrow))
            {
                rb.gravityScale = 0;
                rb.velocity = new Vector2(rb.velocity.x, 2);
                animator.SetInteger("Cambio", 3);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                rb.gravityScale = 0;
                rb.velocity = new Vector2(rb.velocity.x, -2);
                animator.SetInteger("Cambio", 3);
            }
        }
        if(!estaEnSuelo && !escalera)
        {

            tiempo += Time.deltaTime;
            Debug.Log("El tiempo es: " + tiempo);

            if (tiempo > 0.5 && rb.gravityScale == 10)
            {
                animator.SetInteger("Cambio",5);
            }
            if (Input.GetKey(KeyCode.X)) {
                rb.gravityScale = 1;
                animator.SetInteger("Cambio", 4);
            }
        }
        if (Input.GetKey(KeyCode.C))
            animator.SetInteger("Cambio",6);

        if (Input.GetKeyUp(KeyCode.V))
        {
            Instantiate(Kunai, _transform.position, Quaternion.identity);
        }

        if(Input.GetKey(KeyCode.V))
            animator.SetInteger("Cambio", 7);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.layer == 8)
        {
            numSaltos = 0;
            estaEnSuelo = true;
            tiempo = 0;
        }
        else
            estaEnSuelo = false;

    }


private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            estaEnSuelo = true;
            tiempo = 0;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            estaEnSuelo = false;
        }
    }
    public void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Cruz")
        {
            escalera = true;
            tiempo = 0;
        }
    }
    public void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Cruz")
            escalera = false;
    }
}
