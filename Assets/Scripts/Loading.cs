using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Loading : MonoBehaviour
{
    // Pour organiser et ne pas se tromper de scène à charger
    [SerializeField] private string SceneName;

    // Pour le prefab à charger
    [SerializeField] private GameObject sceneToLoad;

    // Ajout d'une coroutine pour limiter le temps d'apparition de l'écran de chargement / prefab
    public void LoadSceneAsync()
    {
        StartCoroutine(LoadScreenCoroutine());
    }

    IEnumerator LoadScreenCoroutine()
    {
        // Instantiation du prefab
        var screen = Instantiate(sceneToLoad);
        // Ne pas détruire l'écran de chargement / prefab
        DontDestroyOnLoad(screen);

        // Nom de la scène à charger
        var loading = SceneManager.LoadSceneAsync("Game");
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

    }
}

