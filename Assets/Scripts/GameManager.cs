using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager inst;
    [SerializeField] Text scoreText;
    [SerializeField] PlayerMovement playerMovement;

    private int score = 0;

    private void Awake()
    {
        inst = this;
    }

    private void Start()
    {
        UpdateScoreText();
    }

    public void CollectCoin()
    {
        IncrementScore();
        //it will increase the player's speed if the player took the coin
        playerMovement.IncreaseSpeed(); 
    }

    void IncrementScore()
    {
        score++;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        scoreText.text = "SCORE: " + score;
    }
}
