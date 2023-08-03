using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // 這是一個自訂方法，配合Unity的動畫編輯器用
    void AnimationEnd()
    {
        Destroy(gameObject); //消滅物件
    }
}
