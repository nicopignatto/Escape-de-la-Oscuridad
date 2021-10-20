using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPJ : MonoBehaviour
{
    [Header("linkeos/referencias a objetos")]
   
    [SerializeField] private GameObject balita;
    [SerializeField] private float shootCooldown;
    private float shootCooldownActual;
        
    private void Start() {
        shootCooldownActual = 0;
    }
    private void Update()
    {
       
        
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (shootCooldownActual <= 0) 
            {
                FindObjectOfType<AudioManager>().Play("flechaDisparo");

                shootCooldownActual = shootCooldown;
                Instantiate(balita, transform.position, Quaternion.identity);
            }
        }
        shootCooldownActual -= Time.deltaTime;
    }

}
