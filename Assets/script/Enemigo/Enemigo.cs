using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    [SerializeField]int vida = 10; 
    private float tiempo;
    private float tiempoC;
    private GameObject jugador;
    [SerializeField] GameObject lanza;
    [SerializeField] Animator anim;
    [SerializeField] int tiepCamb;
    [SerializeField] bool movHorizontal;
    [SerializeField] bool movAtaque;
    [SerializeField] float distanciaAtaque;
    [SerializeField] float distanciaGolpeo;
    

    [SerializeField] private Rigidbody2D rb2D;

    [Header("velocidad")]
    [SerializeField] private float velMov;

    private bool haciaIz;

    private Quaternion rotacionPersonaje;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        jugador = GameObject.Find("Jugador");
        
    }

    private void FixedUpdate()
    {
        float distanciaEntreEA = Vector3.Distance(jugador.transform.position, transform.position);
        if (movHorizontal == true)
        {
            MovLado();
            Tempo();
        }
        
      
        if (distanciaEntreEA < distanciaAtaque && distanciaEntreEA > distanciaGolpeo)
        {
            movAtaque = true;
        }
        if (movAtaque == true)
        {
            MovAtaque();
        }
   

        if (vida <= 0)
        {
            movAtaque = false;
            rb2D.velocity = new Vector2(0, rb2D.velocity.y);
            anim.SetBool("muerte", true);
            Destroy(this.gameObject, 1);
        }

        Atacar();
    }
   
    void Atacar()
    {
        if (Vector3.Distance(jugador.transform.position, transform.position) < distanciaGolpeo)
        {
            Cooldown();
            movAtaque = false;
            rb2D.velocity = new Vector2(0, rb2D.velocity.y);
            anim.SetBool("atacando", true);
            anim.SetBool("caminando", false);
        }
        else
        {
            anim.SetBool("atacando", false);
            movAtaque = true;
        }
    }
    private void MovAtaque()
    {
        
        
            anim.SetBool("caminando", true);
            
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

    private void MovLado()
    {
        anim.SetBool("caminando", true);
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
            movAtaque = true;
        }
    }


    void Cooldown()
    {
        tiempoC += Time.deltaTime;

        if (tiempoC < 0.5)
        {
            lanza.transform.localScale = new Vector3(1, 1, 1);
        }
        
        if (tiempoC > 0.5)
        {
            lanza.transform.localScale = new Vector3(0, 1, 1);
        }

        if (tiempoC > 1)
        {
            tiempoC = 0;
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
