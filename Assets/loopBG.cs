using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loopBG : MonoBehaviour
{
    public Transform loop1;
    public Transform loop2;
    public float speed = 0.1f; 

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        loop1.localPosition += new Vector3(0, -speed, 0);
        loop2.localPosition += new Vector3(0, -speed, 0);

        if (loop1.localPosition.y < -4.42) {
            var pos1 = loop1.localPosition;
            pos1.y = 4.42f;
            loop1.localPosition = pos1;
		}
        if (loop2.localPosition.y < -4.42) {
            var pos2 = loop2.localPosition;
            pos2.y = 4.42f;
            loop2.localPosition = pos2;
        }

    }
}
