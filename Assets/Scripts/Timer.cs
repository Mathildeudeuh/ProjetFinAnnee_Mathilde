using UnityEngine;
using UnityEngine.UI;


public abstract class Timer : MonoBehaviour
{
    public float seconde;
    public float addTime;
    public bool onTrigger;

    [SerializeField] private Text myText;

    void Update()
    {
        var end = FindObjectOfType<GameOver>();

        if (onTrigger == false)
        {
            seconde -= Time.deltaTime;

            myText.text = Mathf.Round(seconde).ToString();
            
            EndOfTheGame();
        }

        else
        {
            onTrigger = false;
        }
    }

    public abstract void EndOfTheGame();
}