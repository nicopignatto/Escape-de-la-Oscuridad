using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{ 
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Inicio()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void salir()
    {
        Application.Quit();
    }
}
