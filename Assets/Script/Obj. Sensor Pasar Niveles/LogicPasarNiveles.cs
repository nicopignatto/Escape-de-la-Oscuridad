using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LogicPasarNiveles : MonoBehaviour
{
    [Header("Booleano que indica si se paso el nivel")]
    [SerializeField] private bool pasasteElNivel;//este booleano sirve para indicar si se completo el nivel y pasar a la escena siguiente

    /*[Header("Indice de Escena Actual")]//esto indica el indice de la escena actual,al que despues más adelante se le suma "1" para poder avanzar a la siguiente escena 
    [SerializeField] private int indiceEscenaActual;*/

    [Header("Nombre de Escena Actual")]
    [SerializeField] private string nombreEscena;

    [Header("Linkeos")]
    [SerializeField] private GameObject jugador; //esta variable hace referencia al jugador

    /*private Scene escenaDeseada;*/  //esta variable hacia referencia a la escena y eso no permite acceder a diferentes aspectos de la escena(POR FAVOR NO BORRAR ESTA LINEA)
    private void Start()
    {
        //Debug.Log(SceneManager.GetActiveScene().buildIndex);//esto era para probar unas cosas de codigo.Basicamente sirve para saber el indice de la escena activa.
        //Debug.Log("el indice de la escena actual es:" + SceneManager.GetActiveScene().buildIndex);
        pasasteElNivel = false;
    }
    private void Update()
    {
        PasarAlSiguienteNivel();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    private void PasarAlSiguienteNivel()//esto sirve mas como opcion de dev.
    {
        if (pasasteElNivel == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

}
/*escenaDeseada.buildIndex*/