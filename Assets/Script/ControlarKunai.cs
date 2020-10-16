using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlarKunai : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject Ninja;
    private Transform _transform;
    private PuntajeController puntajeCoins;

    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        _transform = GetComponent<Transform>();
        Destroy(this.gameObject, 1);
        puntajeCoins = FindObjectOfType<PuntajeController>();
        Debug.Log(puntajeCoins.GetPoints());
    }

    void Update()
    {
        rb.gravityScale = 0;
        var a = Ninja.transform.position.x;
        rb.velocity = new Vector2(-5, rb.velocity.y);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Zombie")
        {
            Destroy(this.gameObject, 0);
            puntajeCoins.AddPoints(10);
            Debug.Log(puntajeCoins.GetPoints());
        }
    }
}
