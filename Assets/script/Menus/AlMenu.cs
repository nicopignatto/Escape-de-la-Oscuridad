using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AlMenu : MonoBehaviour
{
    [SerializeField] GameObject Panel;
    bool pausa;
    [SerializeField] KeyCode Pausa;
    void Start()
    {
        Time.timeScale = 1f;
        Panel.SetActive(false);
        pausa = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(Pausa))
        {


            if (pausa == false)
            {

                Panel.SetActive(true);
                Time.timeScale = 0f;
                pausa = true;

            }

            else
            {

                Panel.SetActive(false);
                Time.timeScale = 1f;
                pausa = false;

            }
        }
    }
    public void IrAlMenu()
    {
        SceneManager.LoadScene("MenuInicio");
    }
}
