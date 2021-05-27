using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    // A modifier dans l'inspector
    // Valeur du temps
    [SerializeField] private float seconde;
    [SerializeField] private float addTime;

    // Afficher le texte
    [SerializeField] private Text myText;

    // Nom de la scène à charger
    [SerializeField] private string sceneName;

    // Prefab qui sert d'écran de chargement
    [SerializeField] private GameObject loadScreen;

    // Booléen
    private bool onTrigger;

    // Pour les animations 
    //private Animator animator;


    void Start()
    {

    }

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
                //LoadSceneAsync();
                Debug.Log("Zero");
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
    /*public void LoadSceneAsync()
    {
        StartCoroutine(LoadScreenCoroutine());
    }

    IEnumerator LoadScreenCoroutine()
    {
        // Instantiation du prefab
        var screen = Instantiate(loadScreen);
        // Ne pas détruire l'écran de chargement / prefab
        DontDestroyOnLoad(screen);

        // Nom de la scène à charger
        var loading = SceneManager.LoadSceneAsync(sceneName);
        // Ne pas lancer la scène
        loading.allowSceneActivation = false;

        // Tant que le chargement n'est pas fini...
        while (loading.isDone == false)
        {
            // Si la chargement atteint 90%...
            if (loading.progress >= 0.9f)
            {
                // ... la scène se lance
                loading.allowSceneActivation = true;
                
                // ... le paramètre d'animation "Dispartion" s'active
                animator.SetBool("Disparition", true);

                // ... et l'écran de chargement / prefab se détruit
                Destroy(screen);
            }

            // Le prefab apparaît pendant 3 secondes
            yield return new WaitForSeconds(3);

        }
    }*/

    // Vérification de collision
    private void OnTriggerEnter2D(Collider2D collision)
    {   
        // Si la collision a lieu avec un objet qui a le tag "Items"...
        if (collision.tag == "Items")
        {
            // ... onTrigger devient vrai
            onTrigger = true;
        }
        
    }

}