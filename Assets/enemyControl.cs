using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyControl : MonoBehaviour
{
    public GameObject explosion; //宣告一個名為explosion的物件

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += new Vector3(0, -0.1f, 0);
    }


    void OnTriggerEnter2D(Collider2D col) //名為col的觸發事件
    {
        if (col.tag == "Player" || col.tag == "Bullet") //如果碰撞的標籤是Player或Bullet
        {

            Instantiate(explosion, transform.position, transform.rotation); //在自己的位置產生爆炸
            if (col.tag == "Player") //如果碰撞的標籤是Player
            {
                //在碰撞物件的位置產生爆炸，也就是在太空船的位置產生爆炸
                Instantiate(explosion, col.gameObject.transform.position, col.gameObject.transform.rotation);
                BGupdate.Instance.GameOver(); // 呼叫GameOver方法
            }
            else 
            {
                BGupdate.Instance.AddScore(); //呼叫 BGupdate.cs 底下的AddScore()
            }

            Destroy(col.gameObject); //消滅對象物件
            Destroy(gameObject); //消滅自己
        }




    }

}
