using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrimerBoss : MonoBehaviour
{
    [SerializeField] float vida = 100;
    Rigidbody2D rb2D;
    
    [SerializeField] float velAt;
    [SerializeField] float velSalto;
    [SerializeField] GameObject EsfIz;
    [SerializeField] GameObject EsfDer;

    [SerializeField] Slider barraVidaBoss;
    SpriteRenderer spriteB;
    bool iz;
    bool der;
    float time1;
    float time2;
    bool terceraFase;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        spriteB = GetComponent<SpriteRenderer>();
        terceraFase = false;
        iz = true;
        der = false;
        spriteB.flipX = true;
    }

    
    void FixedUpdate()
    {
        CambioFase();
        BarraVida();
        
    }

    void BarraVida()
    {
        barraVidaBoss.value = vida;
    }

    void CambioFase()
    {
        if (vida > 70)
        {
            PrimeraFase();
        }
        if (vida <= 70 && vida > 40)
        {
            SegundaFase();
        }

        if (vida <= 40)
        {
            TerceraFase();
            terceraFase = true;
        }
    }

    void PrimeraFase()
    {
        time1 += Time.deltaTime;
        if (time1 > 0.3)
        {
            if (der == true)
            {
                rb2D.velocity = new Vector2(velAt, rb2D.velocity.y);
            }

            if (iz == true)
            {
                rb2D.velocity = new Vector2(-velAt, rb2D.velocity.y);
            }
        }
        else
        {
            rb2D.velocity = new Vector2(0, rb2D.velocity.y);
        }

        if (time1 > 1f)
        {
            time1 = 0;
        }
    }

    void SegundaFase()
    {
        time1 += Time.deltaTime;
        if (time1 > 0.9)
        {
            if (der == true)
            {
                rb2D.velocity = new Vector2(velAt, rb2D.velocity.y);
                rb2D.velocity = new Vector2(rb2D.velocity.x, velSalto);
            }

            if (iz == true)
            {
                rb2D.velocity = new Vector2(-velAt, rb2D.velocity.y);
                rb2D.velocity = new Vector2(rb2D.velocity.x, velSalto);
            }
        }
        else
        {
            rb2D.velocity = new Vector2(0, rb2D.velocity.y);
        }

        if (time1 > 2f)
        {
            time1 = 0;
        }
    }

    void TerceraFase()
    {
        if (transform.position.x < -1)
        {
            rb2D.velocity = new Vector2(velAt, rb2D.velocity.y);
        }
        else
        {
            rb2D.velocity = new Vector2(0, rb2D.velocity.y);
        }
        if (transform.position.x > 1)
        {
            rb2D.velocity = new Vector2(-velAt, rb2D.velocity.y);
        }
        else{
            rb2D.velocity = new Vector2(0, rb2D.velocity.y);
        }

        if (transform.position.x < 1 && transform.position.x >-1)
        {
            time2 += Time.deltaTime;
            if(time2 < 0.5f)
            {
                rb2D.velocity = new Vector2(rb2D.velocity.x, velSalto);
            }
            

            if (time2 > 1.3f)
            {
                time2 = 0;
            }  
        }
    }

    void BolasAt()
    {
        Instantiate(EsfIz);
        Instantiate(EsfDer);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bala")
        {
            vida = vida - 1;
            if (vida <= 0)
            {
                Destroy(gameObject, 1f);
                Destroy(barraVidaBoss, 1f);
            }
        }

        if (collision.gameObject.tag == "LimiteIz")
        {
            iz = false;
            spriteB.flipX = false;
            der = true;
            
        }

        if (collision.gameObject.tag == "LimiteDer")
        {
            iz = true;
            spriteB.flipX = true;
            der = false;
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "piso")
        {
            if (terceraFase == true)
            {

                BolasAt();
            }
        }
    }
}
