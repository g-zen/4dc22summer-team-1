using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    Rigidbody2D rb;

    [Header("移動力"), SerializeField] float movePower = 3500f;
    [Header("つっぱり力"), SerializeField] float Force = 160f;

    [SerializeField]Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float vec = rb.velocity.magnitude;
        anim.SetFloat("Speed", vec);
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
        dir = dir * movePower * Time.deltaTime;
        //if (rb.velocity.magnitude < 20) //多分制限速度
        {
            rb.AddForce(dir); // 力を加える
        }
        if (Input.GetKeyUp(KeyCode.Z) || Input.GetButtonUp("Fire1"))
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
        rb.AddForce(dir*Force, ForceMode2D.Impulse);

    }
}