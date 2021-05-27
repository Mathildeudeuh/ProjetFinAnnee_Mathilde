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
        var timer = FindObjectOfType<Timer>();
        timer.AddTime();
    }
}
