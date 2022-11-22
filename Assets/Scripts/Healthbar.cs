using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Healthbar : MonoBehaviour //este código, se le asigna al jugador.
{
    public Image healthbar; //Le dices a la imagen que se ponga, teniendo esta el nombre de "Barra de vida"
    public float life = 100; //Creas una variable de "vida" con un máximo de está.

    void Update()
    {
        life = Mathf.Clamp(life, 0, 100); //hace que nuestra vida no pase del máximo ni del mínimo.
        healthbar.fillAmount = life / 100;
        if (life <= 0)
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
