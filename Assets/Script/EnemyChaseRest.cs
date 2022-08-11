using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyChaseRest : MonoBehaviour
{
    GameObject[] Player; 
    GameObject target;
    Rigidbody2D rb;
    EnemyState state;
    float CurrentTime = 0;
    [Header("攻撃と待機が入れ変わる時間"), SerializeField]float LimitTime;
    
    public enum EnemyState
    {
        wait=0,
        attack=1,
        end=2
    }
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectsWithTag("Player");
        target = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>(); 
        state = EnemyState.attack;

    }

    // Update is called once per frame
    void Update()
    {
        //時間を測る
        CurrentTime += Time.deltaTime;
        if(state == EnemyState.wait){
            Debug.Log("待機");

        }else if(state == EnemyState.attack){
            // 対象物へのベクトルを算出
            Vector2 toDirection = target.transform.position - transform.position;
            // 対象物へ回転する
            transform.rotation = Quaternion.FromToRotation(Vector2.up, toDirection);
            this.transform.Translate(Vector2.up * Time.deltaTime * 0.9f);
            if (rb.velocity.magnitude < 3) {
                rb.AddForce (toDirection); // 力を加える
            }
        }

        //終わった時end状態の移行
        if(GameManager.instance.isGameOver == true){
            //速さを0にする
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;
            state = EnemyState.end;
            }else if(CurrentTime >= LimitTime){
                CurrentTime=0;
                //Stateを変える処理
                //wait
                if(state == EnemyState.wait){
                    state = EnemyState.attack;
                    //攻撃表示
                    Debug.Log("攻撃中");
                }else if(state == EnemyState.attack){
                    state = EnemyState.wait;
                    Debug.Log("休憩中");
                }
            }

    }
}