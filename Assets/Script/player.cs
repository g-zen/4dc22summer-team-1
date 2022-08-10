using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

          Vector2 force = new Vector2(x, y).normalized;
          force = force * 10;
          if (rb.velocity.magnitude < 7) //‘½•ª§ŒÀ‘¬“x
          {
              rb.AddForce(force); // —Í‚ð‰Á‚¦‚é
          }
    }
}