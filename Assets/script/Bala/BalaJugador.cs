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
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        target = new Vector3(target.x, target.y, 0);
        arma = new Vector3 (transform.position.x, transform.position.y, 0);
        transform.up = target - arma;
        
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

    private void OnTriggerEnter2D(Collider2D collision)
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