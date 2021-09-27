using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrimerBoss : MonoBehaviour
{
    float vida = 1;
    Rigidbody2D rb2D;
    [SerializeField] float velAt;
    [SerializeField] float velSalto;
    bool primeraFase;
    bool segundaFase;
    [SerializeField] Image barraVidaBoss;

    bool iz;
    bool der;
    float time1;
    
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        primeraFase = true;
        segundaFase = false;
        iz = true;
        der = false;
    }

    
    void FixedUpdate()
    {
        CambioFase();
        BarraVida();
        if (primeraFase == true)
        {
            PrimeraFase();
        }

        if (segundaFase == true)
        {
            SegundaFase();
        }
    }

    void BarraVida()
    {
        barraVidaBoss.fillAmount = vida;
    }

    void CambioFase()
    {
        if (vida <= 1 && vida > 0.5f)
        {
            primeraFase = true;
        }
        if (vida <= 0.5f)
        {
            primeraFase = false;
            segundaFase = true;
        }
    }

    void PrimeraFase()
    {
        time1 += Time.deltaTime;
        if (time1 > 0.5)
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
        if (time1 > 0.5)
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

        if (time1 > 1f)
        {
            time1 = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bala")
        {
            vida = vida - 0.01f;
        }

        if (collision.gameObject.tag == "LimiteIz")
        {
            iz = false;
            der = true;
            
        }

        if (collision.gameObject.tag == "LimiteDer")
        {
            iz = true;
            der = false;
            
        }
    }
}
