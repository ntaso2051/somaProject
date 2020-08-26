using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pPlayer : MonoBehaviour
{
    int bodyAttackedNum;
    public int yourTeam;
    public bool death;

    public void init()
    {
        // NavMesh上の初期位置へ。
        bodyAttackedNum = 0;
    }

    void bodyAttacked()
    {
        bodyAttackedNum++;
        if (bodyAttackedNum == 4)
        {
            this.death = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (false)
        {//衝突判定
            bodyAttacked();
        }
        if (this.death) this.init();
    }
}
