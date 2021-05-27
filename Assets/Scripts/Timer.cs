using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    // A modifier dans l'inspector
    // Valeur du temps
    [SerializeField] private float seconde;
    [SerializeField] private float addTime;

    // Afficher le texte
    [SerializeField] private Text myText;

    // GameObejct
    [SerializeField] GameObject gameOver;
    [SerializeField] GameObject scene;

    // Booléen
    private bool onTrigger;

    void Update()
    {
        // Si onTrigger est faux...
        if (onTrigger == false)
        {
            // ... les secondes diminuent
            seconde -= Time.deltaTime;
            // ... le texte affiche les secondes
            myText.text = Mathf.Round(seconde).ToString();

            // Si les secondes sont inférieur à 0...
            if (seconde < 0)
            {
                // ... une nouvelle scène se charge
                gameOver.SetActive(true);
                scene.SetActive(false);
            }
        }

        // Si onTrigger est vrai
        else
        {
            // seconde prend la valeur de addTime
            seconde = addTime;
            myText.text = Mathf.Round(seconde).ToString();
            // ... onTrigger passe en faux
            onTrigger = false;
        }
    }

    // Fonction publique --> peut être appeler dans un autre script
    public void AddTime()
    {
        // seconde prend la valeur de addTime
        seconde = addTime;
    }

}