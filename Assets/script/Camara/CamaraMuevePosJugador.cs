using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraMuevePosJugador : MonoBehaviour
{
    [Header("referencias a objetos/componentes de objetos")]
    [SerializeField] private Transform posDelJugador;
    
    /*public float limiteDerecho;
    public float limiteIzquierdo;
    public float limiteInferior;*/

    private void Start()
    {
        
    }
    private void Update()
    {
        /*if(posDelJugador.position.x <= limiteIzquierdo)
        {
            
            transform.position = new Vector3(limiteIzquierdo, transform.position.y, transform.position.z);
        }
        
     
        if (posDelJugador.position.x >= limiteDerecho)
        {
            
            transform.position = new Vector3(limiteDerecho, limiteInferior, transform.position.z);
        }
        


        if (posDelJugador.position.x > limiteIzquierdo && posDelJugador.position.x < limiteDerecho)
        {
            EnfocarJugador();
        }*/
        this.transform.position = new Vector3(posDelJugador.position.x, posDelJugador.position.y + 2f, transform.position.z);
    }

   /* private void EnfocarJugador()
    {
        transform.position = new Vector3(posDelJugador.position.x, limiteInferior, transform.position.z);
    }*/
}
