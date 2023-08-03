using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clearEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D col) //碰撞事件
    {
        if (col.tag == "Enemy") //如果標籤是Enemy
        {
            Destroy(col.gameObject); //消滅碰撞的物件
        }
    }
}
