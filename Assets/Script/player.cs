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
        if (GameManager.instance.isGameOver)
        {
            Destroy(gameObject);
        }
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector2 dir = new Vector2(x, y).normalized;
        if (dir.magnitude > 0)
        {
            transform.rotation = Quaternion.FromToRotation(Vector2.up, dir);
        }
        dir = dir * 3500 * Time.deltaTime;
        //if (rb.velocity.magnitude < 20) //‘½•ª§ŒÀ‘¬“x
        {
            rb.AddForce(dir); // —Í‚ð‰Á‚¦‚é
        }
        if (Input.GetKeyUp(KeyCode.Z))
        {
            Attack();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Dohyou") == true)
        {
            GameManager.instance.GameOver();
        }
    }
    void Attack()//‚Â‚Á‚Ï‚èŠÖ”
    {
        Vector2 dir = transform.up;
        rb.AddForce(dir*160, ForceMode2D.Impulse);

    }
}