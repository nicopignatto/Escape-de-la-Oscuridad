using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiraMov : MonoBehaviour
{
    private void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        Vector2 MousePo = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(MousePo.x, MousePo.y);
    }



    
}
