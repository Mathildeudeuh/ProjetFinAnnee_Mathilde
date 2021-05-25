using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] private float seconde;
    [SerializeField] private GameObject sceneToLoad;
    [SerializeField] private Text myText;
    [SerializeField] private string sceneName;
    
    void Start()
    {
        
    }

    void Update()
    {
        if (seconde > 0)
        {
            seconde -= Time.deltaTime;
            myText.text = Mathf.Round(seconde).ToString();
            Debug.Log(seconde);
        }

        else
        {
            Debug.Log("STOOOOOP");
            LoadSceneAsync();

        }
        

    }
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

    }
}