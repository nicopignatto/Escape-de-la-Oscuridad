using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaJugador : MonoBehaviour
{
    private Vector3 posMouse;
    private Vector3 posBala;
   
    private Rigidbody2D rb2D;
    [SerializeField] private float velBala; // esta es la velocidad de la bala
    void Start()
    {
        posMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition); // este codigo(desde linea 12 hasta linea 15) se encarga de rotar la bala para que vaya a cualquier posicion.
        posMouse = new Vector3(posMouse.x, posMouse.y, 0f);
        //target = new Vector3(target.x, target.y, 0);
        posBala = new Vector3(transform.position.x, transform.position.y, transform.position.z);
      
        //transform.up = target - arma;
        rb2D = GetComponent<Rigidbody2D>();
        //Destroy(gameObject, 3);

    }
    private void FixedUpdate()
    {
        Atacar();
    }

    void Update()
    {
       // Atacar();
    }

    void Atacar()
    {
        rb2D.MovePosition(posMouse);
        transform.rotation = Quaternion.Euler(posMouse);

        //gameObject.transform.Translate(Vector3.up * velBala * Time.deltaTime);
        Destroy(this.gameObject, 3);

    }

    private void OnTriggerEnter2D(Collider2D collision)//esto estaria bien sí tuviera collider y habría que mejorarlo para que la bala se destruya/desactive cuando colisione con objetos con tag "piso","pared"(basicamente con cosas del escenario,osea que no sea solamente con enemigos)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "piso")
        {
            Destroy(gameObject);
        }
    }
   
    
    
  //----------------------------------------------Este código no se sabe si sirve,NO BORRAR----------------------------------------------------------------------------------
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