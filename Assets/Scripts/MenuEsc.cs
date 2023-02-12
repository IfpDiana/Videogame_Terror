using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuEsc : MonoBehaviour
{
    [SerializeField]
    private GameObject menuPausa;
    [SerializeField]
    private KeyCode teclaPausa = KeyCode.Escape;//tecla por defecto
    
    private bool menuPausaActivo = false;

    void Start()
    {
        menuPausa.SetActive(menuPausaActivo);
    }


    void Update()
    {
        // Comprobar si debe estar activo el menu de pausa
        if(Input.GetKeyDown(teclaPausa))
        {
            Cursor.lockState = CursorLockMode.None;// desboqueas el cursor
            menuPausaActivo = !menuPausaActivo; // Cambiamos de true a false y viceversa
            
            // Activarlo o no
            menuPausa.SetActive(menuPausaActivo);
        }
    }

    public void GoPrincipalMenu()
    {


        SceneManager.LoadScene("Menu");///Ir al menu principal
    }

    public void QuitGame()///salir del juego
    {
        Application.Quit();
    }
}
