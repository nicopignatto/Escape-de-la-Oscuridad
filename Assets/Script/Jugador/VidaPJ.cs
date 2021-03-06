using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class VidaPJ : MonoBehaviour
{

    [SerializeField] private int vida;
    public Slider barraVida;
    [SerializeField] Animator anim;
    float tiempo = 0;
    Rigidbody2D rb2D;

    Scene escenaAct;
    
    
    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        escenaAct = SceneManager.GetActiveScene();
        
        
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

            //anim.SetBool("muerto",true);
            Debug.Log("Haz Muerto");
            //Destroy(rb2D);

            tiempo += Time.deltaTime;

            if ( tiempo > 2f)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
            }

            
        }
    }

    void BarraVida()
    {
        barraVida.value = vida;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            vida = vida - 1;
            FindObjectOfType<AudioManager>().Play("playerHit");

        }

        if (collision.gameObject.tag == "Oscuridad")
        {
            vida = vida - 20;
            FindObjectOfType<AudioManager>().Play("playerDead");
            Debug.Log("player colisiona con oscuridad");
            Destroy(rb2D);


        }
    }

    private void OnTriggerStay2D(Collider2D collision) // agregue esta linea de codigo para que cuando sigas colisionando con la oscuridad se te reste vida.
    {
        if (collision.gameObject.tag == "Oscuridad")
        {
            vida = vida - 20;
        }
    }

}
