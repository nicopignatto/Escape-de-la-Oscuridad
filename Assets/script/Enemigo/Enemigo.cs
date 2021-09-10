using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    [SerializeField]int vida = 10; 
    private float tiempo;
    private GameObject jugador;
    [SerializeField] int tiepCamb;
    [SerializeField] bool movHorizontal;
    [SerializeField] bool movAtaque;
    [SerializeField] float distanciaAtaque;
    private bool atacar;

    [SerializeField] private Rigidbody2D rb2D;

    [Header("velocidad")]
    [SerializeField] private float velMov;

    private bool haciaIz;

    private Quaternion rotacionPersonaje;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        jugador = GameObject.Find("Jugador");
        atacar = false;
    }

    private void FixedUpdate()
    {
        if (movHorizontal == true)
        {
            MovLado();
            Tempo();
        }
        
        if (movAtaque == true)
        {
            if (Vector3.Distance(jugador.transform.position, transform.position) < distanciaAtaque)
            {
                atacar = true;
            }
            if (atacar == true)
            MovAtaque();
        }

        if (vida <= 0)
        {
            Destroy(this.gameObject);
        }
    }
   
    private void MovAtaque()
    {
        if (atacar == true)
        {

            if (transform.position.x > jugador.transform.position.x)
            {
                rb2D.velocity = new Vector2(-velMov, rb2D.velocity.y);

                rotacionPersonaje = Quaternion.Euler(0f, 180f, 0f);
                transform.rotation = rotacionPersonaje;
            }
            else
            {
                if (transform.position.x < jugador.transform.position.x)
                {
                    rb2D.velocity = new Vector2(velMov, rb2D.velocity.y);

                    rotacionPersonaje = Quaternion.Euler(0f, 0f, 0f);
                    transform.rotation = rotacionPersonaje;
                }

            }
        }
    }

    private void MovLado()
    {
        if (haciaIz == true)
        {
            rb2D.velocity = new Vector2(-velMov, rb2D.velocity.y);
           
            rotacionPersonaje = Quaternion.Euler(0f, 180f, 0f);
            transform.rotation = rotacionPersonaje;
        }
        else
        {
            if (haciaIz == false)
            {
                rb2D.velocity = new Vector2(velMov, rb2D.velocity.y);
                
                rotacionPersonaje = Quaternion.Euler(0f, 0f, 0f);
                transform.rotation = rotacionPersonaje;
            }
          
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Bala")
        {
            vida = vida - 1;
            atacar = true;
        }
    }

    

    void Tempo()
    {
        tiempo += Time.deltaTime;

        if (tiempo > tiepCamb)
        {
            tiempo = 0f;

            if (haciaIz == true)
            {
                haciaIz = false;
            }

            else
            {
                haciaIz = true;
            }

            tiempo = 0;
        }
    }
}
