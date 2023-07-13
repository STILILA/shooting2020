using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playerControl : MonoBehaviour
{
    public GameObject Bullet; //宣告一個物件叫Bullet
    public float BulletDelay; //子彈間隔

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_ANDROID
        // for Android ver (會自動偵測輸出模式的緣故，不符合目前輸出模式的部分會自動無效化)
        if (Input.GetTouch(0).phase == TouchPhase.Moved) //如果觸控的狀態是拖曳
        {
            float x = Input.touches[0].deltaPosition.x * Time.deltaTime * 0.5f;
            float y = Input.touches[0].deltaPosition.y * Time.deltaTime * 0.5f;
            transform.Translate(new Vector3(x, y, 0));
        }
        //每隔0.15秒產生一個子彈
        BulletDelay += Time.deltaTime;
        if (BulletDelay > 0.15f && BGupdate.Instance.IsPlaying) 
        {
            Vector3 Bullet_pos = gameObject.transform.position + new Vector3(0, 0.6f, 0);
            Instantiate(Bullet, Bullet_pos, gameObject.transform.rotation);
            BulletDelay = 0f;
        }
#else
        // for PC ver
        // L move
        if (Input.GetKey(KeyCode.LeftArrow)) // GetKey = press
        {
            gameObject.transform.position += new Vector3(-0.1f, 0, 0);
        }
        // R move
        if (Input.GetKey(KeyCode.RightArrow))  
        {
            gameObject.transform.position += new Vector3(0.1f, 0, 0);
        }
        // shoot
        if (Input.GetKey(KeyCode.Space)) // GetKeyDown = trigger
        {
            Vector3 pos = gameObject.transform.position + new Vector3(0, 0.6f, 0); //  子彈出現位置 = 自機y + 0.6單位
            Instantiate(Bullet, pos, gameObject.transform.rotation);
        }

#endif


    }
}
