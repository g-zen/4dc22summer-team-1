using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss : MonoBehaviour
{
    GameObject[] Player; 
    GameObject target;
    Rigidbody2D rb;
    EnemyState state;
    float CurrentTime = 0;
    float LimitTime = 3;
    float AdditionalTime = 2;
    int SpinCounter = 0;
    float SpinTime = 0;
    float SpinLimit = 3;
    float SpinRelease = 7;
    
    public enum EnemyState
    {
        wait=0,
        attack=1,
        end=2,
        bossSpin=3
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
        
        //待機状態分岐
        if(state == EnemyState.wait){
            CurrentTime += AdditionalTime;
            Debug.Log("待機");

        ///攻撃状態分岐
        }else if(state == EnemyState.attack){
        // 対象物へのベクトルを算出
        Debug.Log("攻撃");
            Vector2 toDirection = target.transform.position - transform.position;
            // 対象物へ回転する
            transform.rotation = Quaternion.FromToRotation(Vector2.up, toDirection);
            this.transform.Translate(Vector2.up * Time.deltaTime * 0.9f);
            if (rb.velocity.magnitude < 3) {
                rb.AddForce (toDirection); // 力を加える
            }

        //スピン状態
        }else if(state == EnemyState.bossSpin){
            Debug.Log("回転");
            if(SpinTime < SpinLimit){
                SpinTime += Time.deltaTime;
                Debug.Log("ぐるぐる");
                transform.Rotate(new Vector3(0,0,4.0f));
                Vector2 toDirection = target.transform.position - transform.position;
                this.transform.Translate(Vector2.up * Time.deltaTime * 10.9f);
                rb.velocity = Vector2.zero;
            }else{
            SpinTime = 0;
            CurrentTime = 0;//入れてもダメだった
            state = EnemyState.attack;
            }

        }

        //終了状態分岐
        if(GameManager.instance.isGameOver == true){
            //速さを0にする
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;
            state = EnemyState.end;
        }else if(SpinCounter == 3){
            state = EnemyState.bossSpin;
            SpinCounter = 0;
        }else if(CurrentTime >= LimitTime){
            Debug.Log("回転準備");
            CurrentTime=0;
            //Stateを変える処理
            if(state == EnemyState.wait){
                state = EnemyState.attack;
                //攻撃表示
                Debug.Log("攻撃準備");
                SpinCounter += 1;
            }else if(state == EnemyState.attack){
                state = EnemyState.wait;
                Debug.Log("休憩中");
                SpinCounter += 1;
            }
        }


    }
}
