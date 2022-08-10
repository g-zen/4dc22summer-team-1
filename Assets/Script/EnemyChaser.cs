using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaser : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField]GameObject target;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
   
    void Update()
    {
        // 対象物へのベクトルを算出
        Vector2 toDirection = target.transform.position - transform.position;
        // 対象物へ回転する
        transform.rotation = Quaternion.FromToRotation(Vector2.up, toDirection);
        this.transform.Translate(Vector2.up * Time.deltaTime * 0.9f);

        if (rb.velocity.magnitude < 3) {
            rb.AddForce (toDirection); // 力を加える
            }

    }
}
