using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseRest : MonoBehaviour
{
    GameObject[] Player; 
    GameObject target;
    Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectsWithTag("Player");
        target = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>(); 
        
    }

    // Update is called once per frame
    void Update()
    {
        //Player_Objects = GameObject.FindGameObjectsWithTag("Player");
        if(Player.Length == 0){
            Destroy(this.gameObject);
        }else{

            //target = Vector2.Distance(obs.transform.position, nowObj.transform.position);
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
}
