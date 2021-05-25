using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float seconde;

    void Update()
    {
        if (seconde > 0)
        {
            seconde -= Time.deltaTime;
            Debug.Log(seconde);
        }
    }
}