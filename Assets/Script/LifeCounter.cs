using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeCounter : MonoBehaviour
{
    public List<GameObject> lifes;

    public void LifeRefresh(int life) {

        lifes[0].SetActive(life >= 1);
        lifes[1].SetActive(life >= 2);
        lifes[2].SetActive(life >= 3);
    }



}
