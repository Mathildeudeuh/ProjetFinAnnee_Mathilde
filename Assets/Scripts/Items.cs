using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    [SerializeField] public GameObject star;
    public bool starNo = true;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        star.SetActive(false);
        Debug.Log("tkt ça fonctionne");
    }
}
