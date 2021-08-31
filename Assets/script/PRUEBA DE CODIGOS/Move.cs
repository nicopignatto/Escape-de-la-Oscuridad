using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Vector2 adelante;
    public Vector2 atras;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(atras);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(adelante);
        }
    }
}
