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
    [SerializeField] private SpriteRenderer spriteR;

    [Space]

    [Header("velocidad")]
    [SerializeField] private float velMov;
    [SerializeField] private float velSalto;

    private bool estaEnElPiso;
    [SerializeField] Animator anim;

    private Quaternion rotacionPersonaje;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        estaEnElPiso = true;
        spriteR = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        Mov();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "piso")
        {
            estaEnElPiso = true;
            Debug.Log("estoy triggeando");
            anim.SetBool("saltar", false);
        }
    }
    

    //private void OnTriggerExit2D(Collider2D collision)
    //{
      //  if (collision.gameObject.tag == "piso")
        //{
          //  estaEnElPiso = false;
            //Debug.Log("no deberias saltar en teoria");
        //}
    //}

    private void Mov()
    {
        if (Input.GetKey(teclaIzq))
        {
            anim.SetBool("caminar", true);
            rb2D.velocity = new Vector2(-velMov, rb2D.velocity.y);
            spriteR.flipX = true;
            //transform.eulerAngles = new Vector3(0f, 0f, 0f);
            //rotacionPersonaje = Quaternion.Euler(0f, 180f, 0f);
            //transform.rotation = rotacionPersonaje;
        }
        else
        {
            if (Input.GetKey(teclaDer))
            {
                anim.SetBool("caminar", true);
                rb2D.velocity = new Vector2(velMov, rb2D.velocity.y);
                spriteR.flipX = false;
                //transform.eulerAngles = new Vector3(0f, 180f, 0f);
                //rotacionPersonaje = Quaternion.Euler(0f, 0f, 0f);
                //transform.rotation = rotacionPersonaje;
            }
            else
            {
                anim.SetBool("caminar", false);
                rb2D.velocity = new Vector2(0, rb2D.velocity.y);
            }

        }

        if (estaEnElPiso == false)
        {
            
            anim.SetBool("caminar", false);
        }

        if (Input.GetKey(teclaArr) && estaEnElPiso == true)
        {
            anim.SetBool("saltar", true);
            rb2D.velocity = new Vector2(rb2D.velocity.x, velSalto);
            estaEnElPiso = false;
            
        }
        
       
    }

}
