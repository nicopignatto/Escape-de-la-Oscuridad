using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovJugador : MonoBehaviour
{
    [Header("teclas del jugador")]
    [SerializeField] private KeyCode teclaIzq;
    [SerializeField] private KeyCode teclaDer;
    [SerializeField] private KeyCode teclaArr;
    [SerializeField] private KeyCode teclaAbajo;

    [Space]

    [Header("referencias a objetos")]
    [SerializeField] private Rigidbody2D rb2D;

    [Space]

    [Header("velocidad")]
    [SerializeField] private float velMov;
    [SerializeField] private float velSalto;

    private bool estaEnElPiso;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Mov();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "piso")
        {
            estaEnElPiso = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="piso")
        {
            estaEnElPiso = false;
        }
    }

    private void Mov()
    {
        if (Input.GetKey(teclaIzq))
        {
            rb2D.velocity = new Vector2(-velMov, rb2D.velocity.y);
        }

        if (Input.GetKey(teclaDer))
        {
            rb2D.velocity = new Vector2(velMov, rb2D.velocity.y);
        }

        if (Input.GetKey(teclaArr) && estaEnElPiso == true)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, velSalto);
        }
    }
}
