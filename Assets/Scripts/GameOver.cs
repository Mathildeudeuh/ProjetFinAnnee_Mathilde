using UnityEngine;

public class GameOver : Timer
{
    [SerializeField] GameObject gameOver;
    [SerializeField] GameObject scene;

    public override void EndOfTheGame()
    {
        var endTime = FindObjectOfType<Timer>();
            // Si les secondes sont inf?rieur ? 0...
            if (endTime.seconde <= 0)
            {
                // ... une nouvelle sc?ne se charge
                gameOver.SetActive(true);
                scene.SetActive(false);
            }
    }
}