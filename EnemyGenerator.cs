using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : RandomPos
{
    public const int ENEMIES_NUM = 3; //敵の数
    public GameObject[] enemies = new GameObject[ENEMIES_NUM];
    public GameObject enemyPrefab = null;   //適当な敵をプレハブ化してアタッチ
    public float y_MAX = 10;    //ターゲットの出現するyの最大値
    public float y_MIN = 3;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < ENEMIES_NUM; i++)
        {
            float y = Random.Range(y_MIN, y_MAX);
            Vector3 enemyPos = getRandomPos(y);
            enemies[i] = Instantiate(enemyPrefab, enemyPos, Quaternion.identity) as GameObject;
        }
    }
}
