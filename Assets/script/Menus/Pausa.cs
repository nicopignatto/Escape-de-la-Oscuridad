using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausa : MonoBehaviour
{
    bool active;
    Canvas pausa;

    void Start()
    {
        pausa = GetComponent<Canvas>();
        pausa.enabled = false;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            active = !active;
            pausa.enabled = active;
            Time.timeScale = (active) ? 0 : 1f;
        }
        
    }

    public void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
        Time.timeScale = 1f;

    }
}