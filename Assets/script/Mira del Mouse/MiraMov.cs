using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiraMov : MonoBehaviour
{
    [SerializeField] private bool cursorActivo;
    private void Start()
    {
        Cursor.visible = false; //Esto sirve para que cuando uno empieza a jugar el mouse no se vea en la pantalla y no se superponga con la mira
    }

    void Update()
    {
        Vector3 MousePo = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(MousePo.x, MousePo.y, -2);
        ActivarCursor();
        DesactivarCursor();
    }
    //estas funciones nuevas sirven para que los dev. puedan activar/desactivar el cursor del mouse de forma comoda
    
    private void ActivarCursor()
    {
        if (cursorActivo == true)
        {
            Cursor.visible = true;
        }
    }

    private void DesactivarCursor()
    {
        if (cursorActivo == false)
        {
            Cursor.visible = false;
        }
    }


    
}
