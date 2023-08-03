using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyControl : MonoBehaviour
{
    public GameObject explosion; //宣告一個名為explosion的物件

    float moveSpeedX;
    float moveSpeedY;
    int life;
    int score = 10;
    Random randomer = new Random();

    // Start is called before the first frame update
    void Start()
    {
        moveSpeedY = Random.Range(0.08f, 0.16f);

        //if (Random.Range(0, 2) == 1) {
            moveSpeedX = Random.Range(-0.05f, 0.05f);
       // }
        life = Random.Range(1, 8);
        float scaleRate = 1 + 0.15f * (life - 1);
        score = 10 * life;
        gameObject.transform.localScale = new Vector2(scaleRate, scaleRate);

    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += new Vector3(moveSpeedX, -moveSpeedY, 0);
    }


    void OnTriggerEnter2D(Collider2D col) //名為col的觸發事件
    {
        if (col.tag == "Player" || col.tag == "Bullet") //如果碰撞的標籤是Player或Bullet
        {

            var player = col.GetComponent<playerControl>();
            //如果碰撞的是Player
            if (player) { 
                // 非無敵狀態
                if (!col.GetComponent<playerControl>().isMuteki) {
                    //在碰撞物件的位置產生爆炸，也就是在太空船的位置產生爆炸
                    Instantiate(explosion, col.gameObject.transform.position, col.gameObject.transform.rotation);
                    BGupdate.Instance.LifeMinus(); // 呼叫扣命的方法
                    Destroy(gameObject); //消滅自己
                    Instantiate(explosion, transform.position, transform.rotation); //在自己的位置產生爆炸
                    BGupdate.Instance.PlayPlayerBoomSE();
                }

            }
            else 
            {
                life -= 1;
                if (life > 0) {
                    var exp = Instantiate(explosion, col.transform.position, col.transform.rotation); //在自己的位置產生爆炸
                    exp.transform.localScale = new Vector3(0.4f, 0.4f, 1);
                    BGupdate.Instance.PlayHitSE();
                    BGupdate.Instance.AddScore(5);
                } else {
                    BGupdate.Instance.AddScore(score); //呼叫 BGupdate.cs 底下的AddScore()
                   
                    Destroy(gameObject); //消滅自己
                    Instantiate(explosion, transform.position, transform.rotation); //在自己的位置產生爆炸
                    BGupdate.Instance.PlayEnemyBoomSE();
                }
                Destroy(col.gameObject); //消滅對象物件

            }

            
            
        }




    }

}
