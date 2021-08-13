using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiraMov : MonoBehaviour
{
    [SerializeField] private bool cursorActivo;
    private void Start()
    {
      
    }

    void Update()
    {
        Vector2 MousePo = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(MousePo.x, MousePo.y);
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
