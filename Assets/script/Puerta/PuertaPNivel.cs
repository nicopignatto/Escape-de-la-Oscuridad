using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaPNivel : MonoBehaviour
{
    int Boss;
    BoxCollider2D colision;
    void Start()
    {
        colision = GetComponent<BoxCollider2D>();
    }

    
    void Update()
    {
        Boss = GameObject.FindGameObjectsWithTag("Enemy").Length;

        if (Boss == 0)
        {
            Destroy(colision);
            transform.Translate(Vector3.down * 2 * Time.deltaTime);
        }
    }
}
