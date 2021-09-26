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
    //estas variables de abajo ayudan a sacar a el angulo de rotacion de la bala
    Vector3 direccFlechas;
    Vector3 direccObjetivo;
    float anguloRotacionFlechas;
    void Start()
    {
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        target = new Vector3(target.x, target.y, 0);
        direccFlechas = transform.up;
        direccObjetivo = target - transform.position;
        anguloRotacionFlechas = Vector3.SignedAngle(direccFlechas, direccObjetivo, this.transform.forward); 
        arma = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        nuevaDireccionBala = target - arma;
        
       // transform.up = target - arma;
        rb2D = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 3);

    }
    private void FixedUpdate()
    {
        Atacar();
    }

    void Atacar()
    {
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, anguloRotacionFlechas));

        rb2D.velocity = nuevaDireccionBala.normalized * velBala *Time.fixedDeltaTime;
       

        //gameObject.transform.Translate(Vector3.up * velBala * Time.deltaTime);


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "piso")
        {
            Destroy(gameObject, 0.05f);
        }
    }
}