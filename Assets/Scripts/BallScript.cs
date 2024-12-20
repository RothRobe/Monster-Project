using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private readonly Vector2 _velocityVector = new Vector2(1, 0);
    private int _score;

    public GameController gameController;
    // Start is called before the first frame update
    void Start()
    {
        _score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        /*Vector3 position = transform.position;
        Debug.Log(position);
        position.y -= 0.001f;
        transform.position = position;*/
    }
    
    public float bounceForce = 1f;

    void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (collision.gameObject.CompareTag("Paddle"))
        {
            rb.velocity *= _velocityVector;
            // Add upward force when hitting the paddle
            Vector3 bounce = new Vector3(0, bounceForce, 0);
            rb.AddForce(bounce, ForceMode2D.Impulse);

            if (scoreText != null)
            {
                scoreText.text = "Score: " + ++_score;
            }

            return;
        }

        if (collision.gameObject.CompareTag("Floor"))
        {
            gameController.GameOver();
        }
    }
}
