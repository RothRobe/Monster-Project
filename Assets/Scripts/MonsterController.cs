using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    public GameObject ball;
    public SpriteRenderer monsterSprite;
    public float pullForce = 10f;
    private bool _ballSet;
    
    
    private Vector2 minPoint = new Vector2(-8f, 2f);  // Bottom-left corner of the movement area
    private Vector2 maxPoint = new Vector2(8f, 4.5f);  // Top-right corner of the movement area

    public float moveSpeed = 2f;
    private Vector2 targetPosition;

    void Start()
    {
        _ballSet = (ball != null);
        SetRandomTargetPosition();
        Debug.Log(targetPosition);
    }

    void Update()
    {
        MoveTowardsTarget();
        if (_ballSet)
        {
            // Pull the ball toward the monster
            Vector3 direction = (transform.position - ball.transform.position).normalized;
            Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();
            rb.AddForce(direction * pullForce * Time.deltaTime);
        }
    }
    
    void MoveTowardsTarget()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        
        float direction = targetPosition.x - transform.position.x;

        // Flip the sprite based on the direction
        if (direction > 0) // Moving right
        {
            monsterSprite.flipX = true;
        }
        else if (direction < 0) // Moving left
        {
            monsterSprite.flipX = false;
        }

        // Check if the monster has reached the target position
        if ((Vector2)transform.position == targetPosition)
        {
            // Set a new random target position when it reaches the current one
            SetRandomTargetPosition();
        }
    }

    // Set a random target position within the defined area
    void SetRandomTargetPosition()
    {
        // Generate a random point within the min and max points
        float randomX = Random.Range(minPoint.x, maxPoint.x);
        float randomY = Random.Range(minPoint.y, maxPoint.y);

        targetPosition = new Vector2(randomX, randomY);
    }
}
