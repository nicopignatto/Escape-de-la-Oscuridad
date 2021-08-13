using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaJugador : MonoBehaviour
{
    private Vector3 target;
    private Vector3 arma;
    [SerializeField] private float velBala; // esta es la velocidad de la bala
    void Start()
    {
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition); /* este codigo(desde linea 12 hasta linea 15) estuve revisando y no hace nada Agus simplemnte inicializa un vector 3 que no representa a ningun objeto  y hace que rote con "transform.up".    by Nico Pignatto*/
        target = new Vector3(target.x, target.y, 0);
        arma = new Vector3 (transform.position.x, transform.position.y, 0);
        transform.up = target - arma;
        //Importante aclaración:No lo voy a borrar hasta q me expliques bien su funcionalidad(codigo linea 12/linea 15),by Nico Pignatto.
        Destroy(gameObject, 3);

    }


    void Update()
    {
        Atacar();
    }

    void Atacar()
    {
        gameObject.transform.Translate(Vector3.up * velBala * Time.deltaTime);


    }

    private void OnTriggerEnter2D(Collider2D collision)//esto estaria bien sí tuviera collider y habría que mejorarlo para que la bala se destruya/desactive cuando colisione con objetos con tag "piso","pared"(basicamente con cosas del escenario,osea que no sea solamente con enemigos)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
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