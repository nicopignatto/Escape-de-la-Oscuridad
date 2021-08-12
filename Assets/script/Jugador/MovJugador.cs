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

    [Space]

    [Header("velocidad")]
    [SerializeField] private float velMov;
    [SerializeField] private float velSalto;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Mov();
    }

    private void Mov()
    {
        if (Input.GetKey(teclaIzq))
        {
            rb2D.AddForce(Vector2.left * velMov);
        }

        if (Input.GetKey(teclaDer))
        {
            rb2D.AddForce(Vector2.right * velMov);
        }

        if (Input.GetKey(teclaArr))
        {
            rb2D.AddForce(Vector2.up * velSalto);
        }
    }
}
