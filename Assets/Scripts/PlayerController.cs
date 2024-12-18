using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public SpriteRenderer playerSprite;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Basic horizontal movement
        float move = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * move * speed * Time.deltaTime);

        if (move > 0) // Moving right
        {
            playerSprite.flipX = true;
        }
        else if (move < 0) // Moving left
        {
            playerSprite.flipX = false;
        }
        
        // Clamp paddle position within screen bounds
        float clampedX = Mathf.Clamp(transform.position.x, -8.4f, 8.4f);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
    }
}
