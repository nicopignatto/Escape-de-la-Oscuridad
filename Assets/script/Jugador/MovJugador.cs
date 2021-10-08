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
    //esta variables hacen referencia a los objetos en el que se van a posicionar unos raycast´s.
    [SerializeField] private GameObject objetoRaycast1;
    [SerializeField] private GameObject objetoRaycast2;
    [SerializeField] private GameObject objetoRaycast3;
    [Space]

    [Header("velocidad")]
    [SerializeField] private float velMov;
    [SerializeField] private float velSalto;

    private bool estaEnElPiso;
    private RaycastHit2D rayitoPies1;
    private RaycastHit2D rayitoPies2;
    private RaycastHit2D rayitoPies3;
    [SerializeField]private LayerMask capaDelPiso;
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
        Debug.DrawRay(objetoRaycast1.transform.position, Vector3.down.normalized*0.5f, Color.red);
        Debug.DrawRay(objetoRaycast2.transform.position, Vector3.down.normalized * 0.5f, Color.blue);
        Debug.DrawRay(objetoRaycast3.transform.position, Vector3.down.normalized * 0.5f, Color.green);
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "piso")
        {
            estaEnElPiso = true;
            Debug.Log("estoy triggeando");
            anim.SetBool("saltar", false);
        }
    }*/
    

    private void Mov()
    {
        

        rayitoPies1 = Physics2D.Raycast(objetoRaycast1.transform.position, Vector2.down, 0.5f, capaDelPiso);
        rayitoPies2 = Physics2D.Raycast(objetoRaycast2.transform.position, Vector2.down, 0.5f, capaDelPiso);
        rayitoPies3 = Physics2D.Raycast(objetoRaycast3.transform.position, Vector2.down, 0.5f, capaDelPiso);
        if (Input.GetKey(teclaIzq))
        {
            anim.SetBool("caminar", true);
            rb2D.velocity = new Vector2(-velMov, rb2D.velocity.y);
            spriteR.flipX = true;
            //transform.eulerAngles = new Vector3(0f, 180f, 0f);
            //rotacionPersonaje = Quaternion.Euler(0f, 180f, 0f);
            //transform.rotation = rotacionPersonaje;
            //transform.rotation = new Quaternion(0f, 180f, 0f, 0f);
        }
        else
        {
            if (Input.GetKey(teclaDer))
            {
                anim.SetBool("caminar", true);
                rb2D.velocity = new Vector2(velMov, rb2D.velocity.y);
                spriteR.flipX = false;
                //transform.eulerAngles = new Vector3(0f, 0f, 0f);
                //rotacionPersonaje = Quaternion.Euler(0f, 0f, 0f);
                //transform.rotation = rotacionPersonaje;
                //transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
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

        if (rayitoPies1==true)
        {
            //Debug.Log("colisione con el piso"); //esto era para probar que colisionaba con algo;y funciona.Osea se pone en consola este mensaje cuando colisiona con algo dentro de la LayerMask "Pisos del nivel"
            estaEnElPiso = true;
            anim.SetBool("saltar", false);
        }
        else
        {
            if (rayitoPies2==true)
            {
                //Debug.Log("colisione con el piso"); //esto era para probar que colisionaba con algo;y funciona.Osea se pone en consola este mensaje cuando colisiona con algo dentro de la LayerMask "Pisos del nivel"
                estaEnElPiso = true;
                anim.SetBool("saltar", false);
            }
            else
            {
                if (rayitoPies3==true)
                {
                    //Debug.Log("colisione con el piso"); //esto era para probar que colisionaba con algo;y funciona.Osea se pone en consola este mensaje cuando colisiona con algo dentro de la LayerMask "Pisos del nivel"
                    estaEnElPiso = true;
                    anim.SetBool("saltar", false);
                }
                else
                {
                    //Debug.Log("no colisione con el piso"); //esto era para probar que no colisionaba con algo;y funciona.Osea se pone en consola este mensaje cuando no colisiona con algo dentro de la LayerMask "Pisos del nivel"
                    estaEnElPiso = false;
                }
            }
        }
        
        if (Input.GetKey(teclaArr) && estaEnElPiso == true)
        {
            anim.SetBool("saltar", true);
            rb2D.velocity = new Vector2(rb2D.velocity.x, velSalto);
            estaEnElPiso = false;
            
        }
        
       
    }

}
