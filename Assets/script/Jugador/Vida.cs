using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Vida : MonoBehaviour
{

    [SerializeField] float vida = 1f;
    public Image barraVida;

    private void Start()
    {
    
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
            Debug.Log("Haz Muerto");
        }
    }

    void BarraVida()
    {
        barraVida.fillAmount = vida;
    }

    private void OnCollisionEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            vida = vida - 0.3f;
        }
    }

}
