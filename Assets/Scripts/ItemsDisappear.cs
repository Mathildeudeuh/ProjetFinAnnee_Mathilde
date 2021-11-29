using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsDisappear : MonoBehaviour
{
    // Prefab
    [SerializeField] public GameObject star;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Le prefab "star" se désactive
        star.SetActive(false);
    }
}