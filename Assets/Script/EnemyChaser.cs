using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaser : MonoBehaviour
{
     [SerializeField]GameObject target;
    void Start()
    {
        
    }

    // Update is called once per frame
   
    void Update()
    {
        // 対象物へのベクトルを算出
        Vector2 toDirection = target.transform.position - transform.position;
        // 対象物へ回転する
        transform.rotation = Quaternion.FromToRotation(Vector2.up, toDirection);
        
        //this.transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
