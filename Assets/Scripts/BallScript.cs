using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    private readonly Vector2 _velocityVector = new Vector2(1, 0);
    // Start is called before the first frame update
    void Start()
    {
        
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
        }
    }
}
