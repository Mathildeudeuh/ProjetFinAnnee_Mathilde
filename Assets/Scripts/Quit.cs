using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour
{
    
    public void QuitGame()
    {
        // Quand on clique sur le bouton "quitter", le jeu se ferme
        Application.Quit();
    }
}
