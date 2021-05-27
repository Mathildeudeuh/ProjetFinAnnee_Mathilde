using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    // Prefab
    [SerializeField] public GameObject star;

    // Booléen
    public bool starNo = true;

    // Vérification de collision
    public void OnTriggerEnter2D(Collider2D collision)
    {
        // Le prefab "star" se désactive
        star.SetActive(false);

        // "ça fonctionne s'affiche dans la console"
        Debug.Log("ça fonctionne");
    }
}
