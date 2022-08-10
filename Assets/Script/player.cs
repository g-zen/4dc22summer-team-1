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
        dir = dir * 1000 * Time.deltaTime;
        //if (rb.velocity.magnitude < 20) //多分制限速度
        {
            rb.AddForce(dir); // 力を加える
        }
        if (Input.GetKeyDown(KeyCode.Z))
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
    void Attack()//つっぱり関数
    {
        Vector2 dir = transform.up;
        rb.AddForce(dir*90, ForceMode2D.Impulse);

    }
}