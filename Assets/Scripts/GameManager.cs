using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager inst;
    [SerializeField] Text scoreText;
    [SerializeField] PlayerMovement playerMovement;

    private void Awake()
    {
        inst = this;
    }

    private void Start()
    {
        UpdateScoreText();
    }

    public void IncrementScore()
    {
        playerMovement.IncreaseSpeed(); // Increase the player's speed
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        scoreText.text = "SCORE: " + playerMovement.GetSpeed();
    }
}
