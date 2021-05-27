using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    // A modifier dans l'inspector
    //[SerializeField] private GameObject star;
    [SerializeField] private float seconde;
    [SerializeField] private Text myText;
    [SerializeField] private string sceneName;
    [SerializeField] private GameObject loadScreen;

    private bool onTrigger;
    [SerializeField] private float addTime;

    

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

        else
        {
            seconde = addTime;
            myText.text = Mathf.Round(seconde).ToString();
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
        if (collision.tag == "items")
        {
            // onTrigger devient vrai
            onTrigger = true;
        }
        
    }

}