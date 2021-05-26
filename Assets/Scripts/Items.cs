using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    [SerializeField] GameObject star;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var timer = new Timer();
        Debug.Log("tkt ça fonctionne");
        Destroy(star);
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
