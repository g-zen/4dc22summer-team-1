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

        Vector2 dir = new Vector2(x, y).normalized;
        if (dir.magnitude > 0)
        {
            transform.rotation = Quaternion.FromToRotation(Vector2.up, dir);
        }
        dir = dir * 10;
          if (rb.velocity.magnitude < 7) //‘½•ª§ŒÀ‘¬“x
          {
              rb.AddForce(dir); // —Í‚ð‰Á‚¦‚é
          }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Dohyou") == true)
        {
            GameManager.instance.GameOver();
        }
    }
}