using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubEnemy : MonoBehaviour
{
    Rigidbody2D rb;

    EnemyState State;

    [Header("攻撃間隔"), SerializeField] float WaitTime = 1.0f;
    float time = 0;

    [SerializeField] GameObject target;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        State = EnemyState.wait;
    }

    // Update is called once per frame

    void Update()
    {
        if (State == EnemyState.attack)
        {
            // 対象物へのベクトルを算出
            Vector2 toDirection = target.transform.position - transform.position;
            // 対象物へ回転する
            transform.rotation = Quaternion.FromToRotation(Vector2.up, toDirection);
            this.transform.Translate(Vector2.up * Time.deltaTime * 0.9f);

            if (rb.velocity.magnitude < 3)
            {
                rb.AddForce(toDirection); // 力を加える
            }
        }

        time += Time.deltaTime;
        if (time >= WaitTime)
        {
            time = 0;
            ChangeState(State);
        }

    }

    public void ChangeState(EnemyState nowState)
    {
        switch (nowState)
        {
            case EnemyState.wait:
                State = EnemyState.attack;
                break;
            case EnemyState.attack:
                State = EnemyState.wait;
                break;
        }
            
    }

    public enum EnemyState
    {
        wait=0,
        attack=1
    }
}
