using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour
{
    // Quand on clique sur le bouton "quitter", le jeu se ferme
    public void QuitGame()
    {
        Application.Quit();
    }
}
