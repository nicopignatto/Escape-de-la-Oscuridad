using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaJugador : MonoBehaviour
{
    private Vector3 target;
    private Vector3 arma;
    private Vector3 nuevaDireccionBala;
    
   
    private Rigidbody2D rb2D;
    [SerializeField] private float velBala; // esta es la velocidad de la bala
    void Start()
    {
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition); // este codigo(desde linea 12 hasta linea 15) se encarga de rotar la bala para que vaya a cualquier posicion.
      
        target = new Vector3(target.x, target.y, 0);
        arma = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        nuevaDireccionBala = target - arma;
        
        //transform.up = target - arma;
        rb2D = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 3);

    }
    private void FixedUpdate()
    {
        Atacar();
    }

    void Atacar()
    {

        rb2D.velocity = nuevaDireccionBala * velBala *Time.fixedDeltaTime;
        //gameObject.transform.Translate(Vector3.up * velBala * Time.deltaTime);
        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "piso")
        {
            Destroy(gameObject, 0.05f);
        }
    }
   
    
    
  //----------------------------------------------Este c�digo no se sabe si sirve,NO BORRAR----------------------------------------------------------------------------------
    /*[Header("velocidad de la flecha/bala")]
    [SerializeField] private float velBala;

    private Rigidbody2D rb2D;

    private void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();       
    }

    private void FixedUpdate()
    {
        rb2D.MovePosition(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
    }*/
}