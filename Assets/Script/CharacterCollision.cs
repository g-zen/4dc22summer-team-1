using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCollision : MonoBehaviour
{
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey (KeyCode.UpArrow)) {
            Vector2 force = new Vector2(3, 0);
        if (rb.velocity.magnitude < 3) {
            rb.AddForce (force); // 力を加える
            }
        }

        
        
        
    }
}

