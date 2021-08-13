using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [Header("linkeos/referencias a objetos")]
    [SerializeField] private GameObject balita;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(balita,transform.position,Quaternion.identity);
           
        }
    }

}
