using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraMuevePosJugador : MonoBehaviour
{
    [Header("referencias a objetos/componentes de objetos")]
    [SerializeField] private Transform posDelJugador;
    private void Start()
    {
        EnfocarJugador();
    }
    private void Update()
    {
        EnfocarJugador();
    }

    private void EnfocarJugador()
    {
        transform.position = new Vector3(posDelJugador.position.x, posDelJugador.position.y, transform.position.z);
    }
}
