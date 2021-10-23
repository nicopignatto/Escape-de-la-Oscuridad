using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogicCreditos : MonoBehaviour
{
    [Header("Tiempo antes de ir al Menu Principal")]
    [SerializeField] private float tiempoAnimacion;
    void Start()
    {
        Invoke("IrAlMenuPrincipal", tiempoAnimacion);
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            IrAlMenuPrincipal();
        }
    }
    private void IrAlMenuPrincipal()
    {
        SceneManager.LoadScene("MenuInicio");
    }
}
