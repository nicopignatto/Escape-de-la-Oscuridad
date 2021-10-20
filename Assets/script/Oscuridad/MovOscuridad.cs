using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovOscuridad : MonoBehaviour
{
    [Header("Velocidad de la oscuridad")]
    [Range(0, 5)]
    [SerializeField] private float velOscuridad;
    
    [Header("Limites de movimiento")]
    [SerializeField] private float limiteDerecho;

    [Header("Linkeos de objetos")]
    [SerializeField] private GameObject jugador;
    [SerializeField] private AudioSource sonidoOscuridad;

    private Rigidbody2D rb2D;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        sonidoOscuridad.volume = 0.1f;
    }

    private void Update()
    {
        //Debug.Log(Vector2.Distance(transform.position, jugador.transform.position));
    }

    private void FixedUpdate()
    {
        Movimiento();

        //if (Vector2.Distance(transform.position, jugador.transform.position) == 74)
        //{
        //    sonidoOscuridad.volume = 0.1f;
        //    Debug.Log("volumen = 0.5");

        //}
        //else if (Vector2.Distance(transform.position, jugador.transform.position) == 60)
        //{
        //    sonidoOscuridad.volume = .20f;
        //    Debug.Log("volumen = 1");

        //}
        
        //else
        //{
        //    sonidoOscuridad.volume = 0.25f;
        //    Debug.Log("volumen = 0.25");

        //}
    }


    private void Movimiento()
    {
        if (transform.position.x < limiteDerecho)
        {
            rb2D.MovePosition(new Vector2(transform.position.x + velOscuridad * Time.fixedDeltaTime, transform.position.y));

        }
        else
        {
            Invoke("DesactivarOscuridad", 3.5f);
        }        

    }

    private void DesactivarOscuridad()
    {
        gameObject.SetActive(false);
    }

}