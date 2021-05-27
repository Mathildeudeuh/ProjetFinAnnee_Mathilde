using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    // Prefab
    [SerializeField] public GameObject star;

    // Booléen
    private bool starNo = true;

    // Vérification de collision
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Le prefab "star" se désactive
        star.SetActive(false);

        // timer va chercher dans le script "Timer"
        var time = FindObjectOfType<Timer>();

        // On exécute AddTime() du script Timer
        time.AddTime();
    }
}
