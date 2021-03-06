using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EsferaDer : MonoBehaviour
{
    Rigidbody2D rb2D;
    
    [SerializeField] float velAt;
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        //reproducir bola se dispara

        FindObjectOfType<AudioManager>().Play("bossShot");


    }

    // Update is called once per frame
    void Update()
    {
        rb2D.velocity = new Vector2(velAt, rb2D.velocity.y);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "piso")
        {
            //reproducir bola colisiona

            FindObjectOfType<AudioManager>().Play("ballHit");

            Destroy(gameObject);
        }
    }
}
