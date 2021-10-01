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
    private Rigidbody2D rb2D;
    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        Movimiento();
    }
    private void Movimiento()
    {
        if (transform.position.x < limiteDerecho)
        {
            rb2D.MovePosition(new Vector2(transform.position.x + velOscuridad * Time.fixedDeltaTime, transform.position.y));
        }
        else
        {
            Invoke("DesactivarOscuridad", 5f);
        }
    }

    private void DesactivarOscuridad()
    {
        gameObject.SetActive(false);
    }

}