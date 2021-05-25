using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private float seconde;
    public Text myText;

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
        }
           

    }
}