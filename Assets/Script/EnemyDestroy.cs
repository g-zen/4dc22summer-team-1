using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroy : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Dohyou"))
        {
            EnemyManager.Instance.OnEnemyDie();
            Destroy(gameObject);
        }
    }
}
