using UnityEngine;

public class GameOver : Timer
{
    [SerializeField] GameObject gameOver;
    [SerializeField] GameObject scene;

    public override void EndOfTheGame()
    {
        var endTime = FindObjectOfType<Timer>();
            // Si les secondes sont inférieur à 0...
            if (endTime.seconde <= 0)
            {
                // ... une nouvelle scène se charge
                gameOver.SetActive(true);
                scene.SetActive(false);
            }
    }
}