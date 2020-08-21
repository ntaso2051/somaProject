using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetGenerator : RandomPos
{
    public const int TARGET_NUM = 10;
    public GameObject[] targets = new GameObject[TARGET_NUM];
    public GameObject targetPrefab = null;
    public int targetCnt;
    public const float y_MAX = 10.0f;
    // Start is called before the first frame update
    void Awake()
    {
        targetCnt = TARGET_NUM;
    }
    void Start()
    {
        for (int i = 0; i < TARGET_NUM; i++)
        {
            Vector3 targetPos = getRandomPos(y_MAX);
            targets[i] = Instantiate(targetPrefab, targetPos, Quaternion.identity) as GameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
