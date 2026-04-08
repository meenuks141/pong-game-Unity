using UnityEngine;
using TMPro;

public class Ball : MonoBehaviour
{
    public float speed = 6f;
    private Rigidbody2D rb;

    public int player1Score = 0;
    public int player2Score = 0;

    public TextMeshProUGUI scoreText;

    public int winScore = 5;
    private bool gameOver = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        UpdateScore();
        Launch();
    }

    void Launch()
    {
        if (gameOver) return;

        float x = Random.value < 0.5f ? -1 : 1;
        float y = Random.Range(-0.5f, 0.5f);

        rb.linearVelocity = new Vector2(x, y) * speed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (gameOver) return;

        if (other.name == "Goal-left")
        {
            player2Score++;
            CheckWin();
        }
        else if (other.name == "Goal-right")
        {
            player1Score++;
            CheckWin();
        }
    }

    void CheckWin()
    {
        UpdateScore();

        if (player1Score >= winScore)
        {
            scoreText.text = "Player 1 Wins!";
            EndGame();
        }
        else if (player2Score >= winScore)
        {
            scoreText.text = "Player 2 Wins!";
            EndGame();
        }
        else
        {
            ResetBall();
        }
    }

    void ResetBall()
    {
        rb.linearVelocity = Vector2.zero;
        transform.position = Vector2.zero;
        Invoke("Launch", 1f);
    }

    void UpdateScore()
    {
        scoreText.text = player1Score + " : " + player2Score;
    }

    void EndGame()
    {
        gameOver = true;
        rb.linearVelocity = Vector2.zero;
    }
}