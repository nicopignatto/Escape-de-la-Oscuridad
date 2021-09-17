using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Vida : MonoBehaviour
{
    
    [SerializeField] private float vida = 1f;
    public Image barraVida;
    [SerializeField] Animator anim;
    float tiempo = 0;
    Rigidbody2D rb2D;
    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        Morir();
        BarraVida();
    }

    
    void Morir()
    {
        if (vida <= 0)
        {
            anim.SetBool("muerto",true);
            Debug.Log("Haz Muerto");
            
            tiempo += Time.deltaTime;

            if ( tiempo > 2f)
            {
                    SceneManager.LoadScene("Nivel 1");
            }

            
        }
    }

    void BarraVida()
    {
        barraVida.fillAmount = vida;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            vida = vida - 0.15f;
        }

        if (collision.gameObject.tag == "Oscuridad")
        {
            vida = vida - 20;
        }
    }

}
