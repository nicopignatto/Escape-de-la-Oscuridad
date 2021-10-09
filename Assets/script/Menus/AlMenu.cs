using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class AlMenu : MonoBehaviour
{
    [Header("Linkeos")]
    [SerializeField] private AudioSource repMusicaNivel;
    [SerializeField] GameObject Panel;
    [SerializeField] KeyCode Pausa;
    private bool pausa;
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
                repMusicaNivel.volume = 0.15f;

            }

            else
            {

                Panel.SetActive(false);
                Time.timeScale = 1f;
                pausa = false;
                repMusicaNivel.volume = 0.5f;

            }
        }
    }
    public void IrAlMenu()
    {
        SceneManager.LoadScene("MenuInicio");
    }
}
