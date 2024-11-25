using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public float speed = 10f;
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
        
        // Clamp paddle position within screen bounds
        float clampedX = Mathf.Clamp(transform.position.x, -10f, 10f);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
    }
}
