﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playerControl : MonoBehaviour
{
    public GameObject Bullet; //宣告一個物件叫Bullet
    public float BulletDelay; //子彈間隔
    public float moveSpeed = 0.09f;
    float bulletDelay = 0f;

    public int life = 3; // 殘機

    public bool isMuteki = false;
    public float mutekiTime = 3f;
    float _mutekiTime = 0f;

    public SpriteRenderer spriteRenderer;



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

        if (bulletDelay > 0) {
            bulletDelay -= Time.deltaTime;
        }
        UpdateMuteki();

        if (Input.GetKey(KeyCode.LeftArrow)) // GetKey = press
        {
            gameObject.transform.position += new Vector3(-moveSpeed, 0, 0);
            if (gameObject.transform.position.x < -5) {
                var pos = gameObject.transform.position;
                pos.x = -5;
                gameObject.transform.position = pos;
            }
        }
        // R move
        if (Input.GetKey(KeyCode.RightArrow))  
        {
            gameObject.transform.position += new Vector3(moveSpeed, 0, 0);
            if (gameObject.transform.position.x > 1.672f) {
                var pos = gameObject.transform.position;
                pos.x = 1.672f;
                gameObject.transform.position = pos;
            }
        }

        if (Input.GetKey(KeyCode.UpArrow)) // GetKey = press
        {
            gameObject.transform.position += new Vector3(0, moveSpeed, 0);
            if (gameObject.transform.position.y > 4.7) {
                var pos = gameObject.transform.position;
                pos.y = 4.7f;
                gameObject.transform.position = pos;
            }

        }
        // R move
        if (Input.GetKey(KeyCode.DownArrow)) {
            gameObject.transform.position += new Vector3(0, -moveSpeed, 0);
            if (gameObject.transform.position.y < -4.62) {
                var pos = gameObject.transform.position;
                pos.y = -4.62f;
                gameObject.transform.position = pos;
            }
        }


        // shoot
        if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Z)) && bulletDelay <= 0) // GetKeyDown = trigger
        {
            Vector3 pos = gameObject.transform.position + new Vector3(0, 0.6f, 0); //  子彈出現位置 = 自機y + 0.6單位
            Instantiate(Bullet, pos, gameObject.transform.rotation);
            bulletDelay = BulletDelay; //產生cd


        }

#endif

    }

    public void LifeMinus() {
        life -= 1;
        if (life <= 0) { 
            life = 0;
            Destroy(gameObject);
        } else {
            StartMuteki();
        }

    }

    void StartMuteki() {
        isMuteki = true;
        _mutekiTime = mutekiTime;
        spriteRenderer.color = new Color(1, 1, 1, 0.5f);
    }


    void UpdateMuteki() {
        if (_mutekiTime <= 0) { return; }
        _mutekiTime -= Time.deltaTime;
        if (_mutekiTime <= 0) {
            ClearMuteki();

        }
    }

    void ClearMuteki() {
        isMuteki = false;
        spriteRenderer.color = new Color(1, 1, 1, 1f);
    }


}
