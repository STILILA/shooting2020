using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clearBullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // 消彈
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Bullet") // 當標籤為 Bullet 的物件撞到自己時
        {
            Destroy(col.gameObject); // 移除該物件
        }
    }
}
