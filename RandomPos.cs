using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPos : MonoBehaviour
{
    //ランダム座標取得の関数定義クラス プレイヤーと敵と的に継承
    public const int FIELD_WIDTH = 100;
    public const int FIELD_HEIGHT = 100;

    private float getRandomFloat()
    {
        return Random.Range(-40.0f, 40.0f);
    }
    public Vector3 getRandomPos(float y)
    {
        float x = getRandomFloat();
        float z = getRandomFloat();
        Vector3 randomPos = new Vector3(x, y, z);
        return randomPos;
    }
}
