using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public const float INF = 10000000000000000000.0f;
    public const float groundY = 1.0f;  //接地判定オブジェクトを作る方がよさそう
    public const float gunRange = 1.0f; //弾丸の届く範囲(ターゲットのy座標に依存しそう)
    public bool isMoving = true;
    public bool canAttack = false;
    TargetGenerator targetGene;
    public List<Vector2> targetPosList = new List<Vector2>();
    public GameObject targetOfThis = null;
    public Rigidbody rigidbody = null;
    public float speed = 0.1f;
    Vector3 toTargetVec;
    // Start is called before the first frame update
    void Start()
    {
        //諸々を取得
        targetGene = GameObject.Find("GameManager").GetComponent<TargetGenerator>();
        rigidbody = this.GetComponent<Rigidbody>();
        //ターゲットを決定
        getTargetsPos();
        targetOfThis = getClosestTarget();
        toTargetVec = targetOfThis.transform.position - this.transform.position;
    }

    void getTargetsPos()
    {
        targetPosList.Clear();
        for (int i = 0; i < targetGene.targetCnt; i++)
        {
            if (targetGene.targets[i].activeSelf)
            {
                float x = targetGene.targets[i].transform.position.x;
                float z = targetGene.targets[i].transform.position.z;
                Vector2 targetPosXZ = new Vector2(x, z);
                targetPosList.Add(targetPosXZ);
            }
            else
            {
                Vector2 targetPosXZ = new Vector2(INF, INF);
                targetPosList.Add(targetPosXZ);
            }
        }
    }

    float getDistance(float dx, float dz)
    {
        float distance = dx * dx + dz * dz;
        return distance;
    }

    GameObject getClosestTarget()
    {
        GameObject closestTarget = null;
        float minDis = INF;
        getTargetsPos();    //ターゲットリストの更新
        for (int i = 0; i < targetPosList.Count; i++)
        {
            float dx = targetPosList[i].x - this.transform.position.x;
            float dz = targetPosList[i].y - this.transform.position.z;
            float distance = getDistance(dx, dz);
            if (minDis > distance)
            {
                minDis = distance;
                closestTarget = targetGene.targets[i];
            }
        }
        return closestTarget;
    }

    void checkInRange()
    {
        float distance = INF;
        if (targetOfThis.activeSelf)
        {
            float dx = targetOfThis.transform.position.x - this.transform.position.x;
            float dz = targetOfThis.transform.position.z - this.transform.position.z;
            distance = getDistance(dx, dz);
        }
        if (distance < gunRange)
        {
            isMoving = false;
            canAttack = true;
            rigidbody.velocity = new Vector3(0f, 0f, 0f);
        }
        else
        {
            isMoving = true;
            canAttack = false;
        }
    }
    void attackTarget()
    {
        targetOfThis.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y == groundY)
        {
            checkInRange();
            if (isMoving)
            {
                rigidbody.velocity = new Vector3(toTargetVec.x * speed, 0, toTargetVec.z * speed);
            }
            if (canAttack)
            {
                attackTarget();
                targetOfThis = getClosestTarget();
                if (targetOfThis != null)
                    toTargetVec = targetOfThis.transform.position - this.transform.position;
            }
        }
    }
}
